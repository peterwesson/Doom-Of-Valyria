using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using GuildWars2.Models.Skills;

namespace GuildWars2.Models.JSON
{
    public class SkillFactConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public SkillFact Create(Type objectType, JObject jObject)
        {
            var type = jObject.GetValue("type").ToObject<SkillFactType>();

            switch (type)
            {
                case SkillFactType.AttributeAdjust:
                    return new AttributeAdjustSkillFact();
                case SkillFactType.Buff:
                    return new BuffSkillFact();
                case SkillFactType.ComboField:
                    return new ComboFieldSkillFact();
                case SkillFactType.ComboFinisher:
                    return new ComboFinisherSkillFact();
                case SkillFactType.Damage:
                    return new DamageSkillFact();
                case SkillFactType.Distance:
                    return new DistanceSkillFact();
                case SkillFactType.Duration:
                    return new DurationSkillFact();
                case SkillFactType.Heal:
                    return new HealSkillFact();
                case SkillFactType.HealingAdjust:
                    return new HealingAdjustSkillFact();
                case SkillFactType.NoData:
                    return new NoDataSkillFact();
                case SkillFactType.Number:
                    return new NumberSkillFact();
                case SkillFactType.Percent:
                    return new PercentSkillFact();
                case SkillFactType.PrefixedBuff:
                    return new PrefixedBuffOrConditionSkillFact();
                case SkillFactType.Radius:
                    return new RadiusSkillFact();
                case SkillFactType.Range:
                    return new RangeSkillFact();
                case SkillFactType.Recharge:
                    return new RechargeSkillFact();
                case SkillFactType.Time:
                    return new TimeSkillFact();
                case SkillFactType.Unblockable:
                    return new UnblockableSkillFact();
                default:
                    return new SkillFact();
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(SkillFact).IsAssignableFrom(objectType);
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            var target = Create(objectType, jObject);

            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}