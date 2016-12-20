using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using GuildWars2.Models.Skins;

namespace GuildWars2.Models.JSON
{
    public class SkinConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public Skin Create(Type objectType, JObject jObject)
        {
            var type = jObject.GetValue("type").ToObject<SkinType>();

            switch (type)
            {
                case SkinType.Armor:
                    return new ArmorSkin();
                case SkinType.Weapon:
                    return new WeaponSkin();
                case SkinType.Gathering:
                    return new GatheringSkin();
                case SkinType.Back:
                    return new BackSkin();
                default:
                    return new Skin();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Skin).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var jsonProperties = jObject.Properties().ToList();
            var target = Create(objectType, jObject);

            serializer.Populate(jObject.CreateReader(), target);

            JToken detailsJToken;

            if (jObject.TryGetValue("details", out detailsJToken))
            {
                serializer.Populate(Rename(detailsJToken, new Dictionary<string, string>
                {
                    { "type", "subtype" }
                }).CreateReader(), target);
            }

            return target;
        }

        private JToken Rename(JToken json, Dictionary<string, string> map)
        {
            return Rename(json, name => map.ContainsKey(name) ? map[name] : name);
        }

        private JToken Rename(JToken json, Func<string, string> map)
        {
            var prop = json as JProperty;
            if (prop != null)
            {
                return new JProperty(map(prop.Name), Rename(prop.Value, map));
            }

            var arr = json as JArray;
            if (arr != null)
            {
                var cont = arr.Select(el => Rename(el, map));
                return new JArray(cont);
            }

            var o = json as JObject;
            if (o != null)
            {
                var cont = o.Properties().Select(el => Rename(el, map));
                return new JObject(cont);
            }

            return json;
        }
    }
}