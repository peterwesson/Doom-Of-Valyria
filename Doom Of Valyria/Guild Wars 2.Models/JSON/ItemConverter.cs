using System;
using System.Linq;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using GuildWars2.Models.Items;

namespace GuildWars2.Models.JSON
{
    public class ItemConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public Item Create(Type objectType, JObject jObject)
        {
            var type = jObject.GetValue("type").ToObject<ItemType>();

            switch (type)
            {
                case ItemType.Armor:
                    return new Armor();
                case ItemType.Back:
                    return new BackItem();
                case ItemType.Bag:
                    return new Bag();
                case ItemType.Consumable:
                    return new Consumable();
                case ItemType.Container:
                    return new Container();
                case ItemType.Gathering:
                    return new GatheringTools();
                case ItemType.Gizmo:
                    return new Gizmo();
                case ItemType.MiniPet:
                    return new Miniature();
                case ItemType.Tool:
                    return new SalvageKit();
                case ItemType.Trinket:
                    return new Trinket();
                case ItemType.UpgradeComponent:
                    return new UpgradeComponent();
                case ItemType.Weapon:
                    return new Weapon();
                default:
                    return new Item();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Item).IsAssignableFrom(objectType);
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
                    { "type", "subtype" },
                    { "description", "subdescription" },
                    { "name", "subname" },
                    { "flag", "subflag" }
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