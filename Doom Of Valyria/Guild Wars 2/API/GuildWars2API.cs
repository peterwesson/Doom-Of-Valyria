using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Specialized;
using System.Collections.Generic;

using Newtonsoft.Json;

using GuildWars2.Models.Account;
using GuildWars2.Models.Core;
using GuildWars2.Models.Items;
using GuildWars2.Models.Skins;
using GuildWars2.Models.Guilds;
using GuildWars2.Models.Skills;

namespace GuildWars2.API
{
    public class GuildWars2API : IDisposable
    {
        private const string baseAddress = "https://api.guildwars2.com";

        protected HttpClient HttpClient { get; set; }
        protected string APIkey { get; set; }

        public GuildWars2API(string apiKey = null)
        {
            APIkey = apiKey;

            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(baseAddress);
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (apiKey != null)
            {
                HttpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {APIkey}");
            }            
        }

        public async Task<IEnumerable<Character>> GetCharacters(string apiKey = null)
        {
            var tasks = new List<Task<Character>>();

            foreach (var character in await GetCharacterNames(apiKey))
            {
                tasks.Add(GetCharacter(character, apiKey));
            }

            var characters = await Task.WhenAll(tasks);

            return characters;
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

        public async Task<Mastery> GetMastery(int id)
        {
            return await GetAsync<Mastery>($"/v2/masteries/{id}");
        }

        public async Task<IEnumerable<Mastery>> GetMasteries(List<int> ids)
        {
            return await GetAsync<IEnumerable<Mastery>>("/v2/masteries", new { ids });
        }

        public async Task<IEnumerable<string>> GetCharacterNames(string apiKey = null)
        {
            return await GetAsync<IEnumerable<string>>("/v2/characters", new { access_control = apiKey });
        }

        public async Task<Character> GetCharacter(string characterName, string apiKey = null)
        {
            return await GetAsync<Character>($"/v2/characters/{characterName}", new { access_control = apiKey });
        }

        public async Task<ProfessionInfo> GetProfession(string id)
        {
            return await GetAsync<ProfessionInfo>($"/v2/professions/{id}");
        }

        public async Task<IEnumerable<ProfessionInfo>> GetProfessions(List<int> ids)
        {
            return await GetAsync<IEnumerable<ProfessionInfo>>("/v2/professions", new { ids });
        }

        public async Task<Skill> GetSkill(int id)
        {
            return await GetAsync<Skill>($"/v2/skills/{id}");
        }

        public async Task<IEnumerable<Skill>> GetSkills(List<int> ids)
        {
            return await GetAsync<IEnumerable<Skill>>("/v2/skills", new { ids });
        }

        public async Task<Item> GetItem(int id)
        {
            return await GetAsync<Item>($"/v2/items/{id}");
        }

        public async Task<IEnumerable<Item>> GetItems(List<int> ids)
        {
            return await GetAsync<IEnumerable<Item>>("/v2/items", new { ids });
        }

        public async Task<Skin> GetSkin(int id)
        {
            return await GetAsync<Skin>($"/v2/skins/{id}");
        }

        public async Task<IEnumerable<Skin>> GetSkins(List<int> ids)
        {
            return await GetAsync<IEnumerable<Skin>>("/v2/skins", new { ids });
        }

        public async Task<Color> GetColor(int id)
        {
            return await GetAsync<Color>($"/v2/colors/{id}");
        }

        public async Task<IEnumerable<Color>> GetColors(List<int> ids)
        {
            return await GetAsync<IEnumerable<Color>>("/v2/colors", new { ids });
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