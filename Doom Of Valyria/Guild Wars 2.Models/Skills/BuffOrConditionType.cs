using Newtonsoft.Json;

using GuildWars2.Models.JSON;

namespace GuildWars2.Models.Skills
{
    [JsonConverter(typeof(EnumStringConverter<BuffOrConditionType>))]
    public enum BuffOrConditionType
    {
        Aegis,
        Fury,
        Might,
        Protections,
        Quickness,
        Regeneration,
        Resistance,
        Retaliation,
        Stability,
        Swiftness,
        Vigor,

        Bleeding,
        Blinded,
        Burning,
        Chilled,
        Confusion,
        Crippled,
        Fear,
        Immobile,
        Poisoned,
        Slow,
        Taunt,
        Torment,
        Vulnerability,
        Weakness,

        [EnumName("Signet of Resolve")]
        SignetOfResolve,
        [EnumName("Bane Signet")]
        BaneSignet,
        [EnumName("Signet of Judgement")]
        SignetOfJudgement,
        [EnumName("Signet of Mercy")]
        SignetOfMercy,
        [EnumName("Signet of Wrath")]
        SignetOfWrath,
        [EnumName("Signet of Courage")]
        SignetOfCourage,
        [EnumName("Healing Signet")]
        HealingSignet,
        [EnumName("Dolyak Signet")]
        DolyakSignet,
        [EnumName("Signet of Fury")]
        SignetOfFury,
        [EnumName("Signet of Might")]
        SignetOfMight,
        [EnumName("Signet of Stamina")]
        SignetOfStamina,
        [EnumName("Signet of Rage")]
        SignetOfRage,
        [EnumName("Signet of Renewal")]
        SignetOfRenewal,
        [EnumName("Signet of Stone")]
        SignetOfStone,
        [EnumName("Signet of the Hunt")]
        SignetOfTheHunt,
        [EnumName("Signet of the Wild")]
        SignetOfTheWild,
        [EnumName("Signet of Malice")]
        SignetOfMalice,
        [EnumName("Assassin's Signet")]
        AssassinsSignet,
        [EnumName("Infiltrator's Signet")]
        InfiltratorsSignet,
        [EnumName("Signet of Agility")]
        SignetOfAgility,
        [EnumName("Signet of Shadows")]
        SignetOfShadows,
        [EnumName("Signet of Restoration")]
        SignetOfRestoration,
        [EnumName("Signet of Air")]
        SignetOfAir,
        [EnumName("Signet of Earth")]
        SignetOfEarth,
        [EnumName("Signet of Fire")]
        SignetOfFire,
        [EnumName("Signet of Water")]
        SignetOfWater,
        [EnumName("Signet of the Ether")]
        SignetOfTheEther,
        [EnumName("Signet of Domination")]
        SignetOfDomination,
        [EnumName("Signet of Illusions")]
        SignetOfIllusions,
        [EnumName("Signet of Inspiration")]
        SignetOfInspiration,
        [EnumName("Signet of Midnight")]
        SignetOfMidnight,
        [EnumName("Signet of Humility")]
        SignitOfHumility,
        [EnumName("Signet of Vampirism")]
        SignetOfVampirism,
        [EnumName("Plague Signet")]
        PlagueSignet,
        [EnumName("Signet of Spite")]
        SignetOfSpite,
        [EnumName("Signet of the Locus")]
        SignitOfTheLocust,
        [EnumName("Signet of Undeath")]
        SignetOfUndeath,

        [EnumName("Banner of Defense")]
        BannerOfDefense,
        [EnumName("Banner of Discipline")]
        BannerOfDiscipline,
        [EnumName("Banner of Strength")]
        BannerOfStrength,
        [EnumName("Banner of Tactics")]
        BannerOfTactics,
        [EnumName("Battle Standard")]
        BattleStandard,

        [EnumName("Facet of Nature")]
        FacetOfNature,
        [EnumName("Facet of Light")]
        FacetOfLight,
        [EnumName("Facet of Darkness")]
        FacetOfDarkness,
        [EnumName("Facet of Elements")]
        FacetOfElements,
        [EnumName("Facet of Strength")]
        FacetOfStrength,
        [EnumName("Facet of Chaos")]
        FacetOfChaos
    }
}