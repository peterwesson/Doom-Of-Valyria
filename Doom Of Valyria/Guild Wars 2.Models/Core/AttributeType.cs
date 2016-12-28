using GuildWars2.Models.JSON;

namespace GuildWars2.Models.Core
{
    public enum AttributeType
    {
        [EnumName("Boon Duration")]
        BoonDuration,
        [EnumName("Condition Damage")]
        ConditionDamage,
        [EnumName("Expertise")]
        ConditionDuration,
        [EnumName("Ferocity")]
        CritDamage,
        [EnumName("Healing Power")]
        Healing,
        [EnumName("Power")]
        Power,
        [EnumName("Precision")]
        Precision,
        [EnumName("Toughness")]
        Toughness,
        [EnumName("Vitality")]
        Vitality,
        [EnumName("Agony Resistance")]
        AgonyResistance
    }
}