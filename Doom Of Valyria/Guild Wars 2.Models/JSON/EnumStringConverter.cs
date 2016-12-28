using System;
using System.Linq;

using Newtonsoft.Json;

using GuildWars2.Models.Skills;

namespace GuildWars2.Models.JSON
{
    public class EnumStringConverter<T> : JsonConverter where T : struct, IConvertible
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(SkillCategories).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jsonString = (reader.Value as string)
                .Replace(" ", string.Empty)
                .Replace("'", string.Empty);

            var value = Enum.GetValues(typeof(T)).Cast<T>().FirstOrDefault(enumValue => jsonString.Equals(enumValue.ToString(), StringComparison.InvariantCultureIgnoreCase));

            return value;
        }
    }
}