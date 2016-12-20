using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Collections.Specialized;
using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Account;
using GuildWars2.Models.Core;
using GuildWars2.Models.Items;
using GuildWars2.Models.Skins;
using GuildWars2.Models.Guilds;

namespace GuildWars2.API
{
    public class GuildWars2API : IDisposable
    {
        private const string baseAddress = "https://api.guildwars2.com";

        protected HttpClient HttpClient { get; set; }
        protected string APIkey { get; set; }

        public GuildWars2API(string apiKey)
        {
            APIkey = apiKey;
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(baseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {APIkey}");
        }

        public async Task<IEnumerable<Character>> GetCharacters(string apiKey = null)
        {
            var tasks = new List<Task<Character>>();

            foreach (var character in await GetCharacterNames(apiKey))
            {
                tasks.Add(GetCharacter(character, apiKey));
            }

            var characters = await Task.WhenAll(tasks);

            var itemIds = characters.SelectMany(character => character.Equipment).Select(equipmentItem => equipmentItem.ItemId).ToList();
            var skinIds = characters.SelectMany(character => character.Equipment).Where(equipmentItem => equipmentItem.SkinId.HasValue).Select(equipmentItem => equipmentItem.SkinId.Value).ToList();

            var itemsTask = GetItems(itemIds);
            var skinsTask = GetSkins(skinIds);

            await Task.WhenAll(new List<Task>{ itemsTask, skinsTask });

            var items = itemsTask.Result;
            var skins = skinsTask.Result;

            foreach (var equipmentItem in characters.SelectMany(character => character.Equipment))
            {
                equipmentItem.Item = items.FirstOrDefault(item => item.Id == equipmentItem.ItemId);
                equipmentItem.Skin = skins.FirstOrDefault(skin => skin.Id == equipmentItem.SkinId);
            }

            return characters.ToList();
        }

        public async Task<TokenInfo> GetTokenInfo(string apiKey = null)
        {
            return await GetAsync<TokenInfo>("/v2/tokeninfo", new { access_control = apiKey });
        }

        public async Task<AccountInfo> GetAccount(string apiKey = null)
        {
            var account = await GetAsync<AccountInfo>("/v2/account", new { access_control = apiKey });

            account.Masteries = await GetAsync<List<AccountMastery>>("/v2/account/masteries", new { access_control = apiKey });

            return account;
        }

        public async Task<IEnumerable<Mastery>> GetMasteries()
        {
            var masteryIds = await GetAsync<List<int>>("/v2/masteries");

            return await GetAsync<IEnumerable<Mastery>>("/v2/masteries", new { ids = masteryIds });
        }

        public async Task<IEnumerable<string>> GetCharacterNames(string apiKey = null)
        {
            return await GetAsync<IEnumerable<string>>("/v2/characters", new { access_control = apiKey });
        }

        public async Task<Character> GetCharacter(string characterName, string apiKey = null)
        {
            return await GetAsync<Character>($"/v2/characters/{characterName}", new { access_control = apiKey });
        }

        public async Task<IEnumerable<EquipmentItem>> GetCharacterEquipment(string characterName, string apiKey = null)
        {
            return (await GetAsync<Equipment>($"/v2/characters/{characterName}/equipment", new { access_control = apiKey })).EquipmentItems;
        }

        public async Task<Item> GetItem(int id, string apiKey = null)
        {
            return await GetAsync<Item>($"/v2/items/{id}");
        }

        public async Task<IEnumerable<Item>> GetItems(IEnumerable<int> ids, string apiKey = null)
        {
            return await GetAsync<IEnumerable<Item>>($"/v2/items", new { ids = ids });
        }

        public async Task<Skin> GetSkin(int id, string apiKey = null)
        {
            return await GetAsync<Skin>($"/v2/skins/{id}");
        }

        public async Task<IEnumerable<Skin>> GetSkins(IEnumerable<int> ids, string apiKey = null)
        {
            return await GetAsync<IEnumerable<Skin>>($"/v2/skins", new { ids = ids });
        }

        public async Task<IEnumerable<Color>> GetColors()
        {
            var colorIds = await GetAsync<IEnumerable<int>>("/v2/colors");

            var colorsTaken = 0;
            var colors = new List<Color>();
            var colorTasks = new List<Task<IEnumerable<Color>>>();

            while (colorsTaken < colorIds.Count())
            {
                var reducedColorIds = colorIds.Skip(colorsTaken).Take(20);
                colorsTaken += reducedColorIds.Count();

                colorTasks.Add(GetAsync<IEnumerable<Color>>("/v2/colors", new { ids = reducedColorIds }));
            }

            await Task.WhenAll(colorTasks);

            foreach (var colorTask in colorTasks)
            {
                colors.AddRange(colorTask.Result);
            }            

            return colors;
        }

        public async Task<Guild> GetGuild(string id, string apiKey = null)
        {
            var guild = await GetAsync<Guild>($"/v2/guild/{id}");

            var guildForegroundTask = GetGuildEmblemForeground(guild.Emblem.Foreground.Id);
            var guildBackgroundTask = GetGuildEmblemBackground(guild.Emblem.Background.Id);

            await Task.WhenAll(new List<Task> { guildForegroundTask, guildBackgroundTask });

            guild.Emblem.Foreground.ForegroundInfo = guildForegroundTask.Result;
            guild.Emblem.Background.BackgroundInfo = guildBackgroundTask.Result;

            return guild;
        }

        public async Task<GuildEmblemInfo> GetGuildEmblemForeground(int id, string apiKey = null)
        {
            return await GetAsync<GuildEmblemInfo>($"/v2/emblem/foregrounds/{id}", new { access_control = apiKey });
        }

        public async Task<GuildEmblemInfo> GetGuildEmblemBackground(int id, string apiKey = null)
        {
            return await GetAsync<GuildEmblemInfo>($"/v2/emblem/backgrounds/{id}", new { access_control = apiKey });
        }

        public async Task<IEnumerable<GuildMember>> GetGuildMembers(string id)
        {
            return await GetAsync<IEnumerable<GuildMember>>($"/v2/guild/{id}/members");
        }

        public void Dispose()
        {
            if (HttpClient != null)
            {
                HttpClient.Dispose();
            }            
        }

        private async Task<T> GetAsync<T>(string url, dynamic parameters = null)
        {
            var builder = new UriBuilder($"{baseAddress}{url}")
            {
                Query = CreateQuery(parameters).ToString()
            };

            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(builder.ToString()),
                Method = HttpMethod.Get
            };

            var response = await HttpClient.SendAsync(request);

            var obj = default(T);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                obj = JsonConvert.DeserializeObject<T>(json);
            }

            return obj;
        }

        private NameValueCollection CreateQuery(dynamic parameters)
        {
            var query = HttpUtility.ParseQueryString(string.Empty);

            if (parameters != null)
            {
                foreach (var property in parameters.GetType().GetProperties())
                {
                    var value = property.GetValue(parameters);
                    if (value != null)
                    {
                        if (value is IEnumerable<int>)
                        {
                            query[(string)property.Name] = string.Join(",", value as IEnumerable<int>);
                        }
                        else if (value is IEnumerable<string>)
                        {
                            query[(string)property.Name] = string.Join(",", value as IEnumerable<string>);
                        }
                        else
                        {
                            query[(string)property.Name] = (value as object).ToString();
                        }

                    }
                }
            }

            return query;
        }
    }
}