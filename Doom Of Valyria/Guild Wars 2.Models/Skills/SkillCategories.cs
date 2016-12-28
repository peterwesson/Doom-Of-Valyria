using GuildWars2.Models.JSON;

using Newtonsoft.Json;

namespace GuildWars2.Models.Skills
{
    [JsonConverter(typeof(EnumStringConverter<SkillCategories>))]
    public enum SkillCategories
    {
        None = 0,
        DualWield,
        StealthAttack,
        Physical,
        Glyph,
        Signet,
        Shout,
        Trap,
        Well,
        Consecration,
        Meditation,
        SpiritWeapon,
        Symbol,
        Virtue,
        Ward,
        Legend,
        LegendaryAssassin,
        LegendaryCentaur,
        LegendaryDemon,
        LegendaryDwarf,
        Banner,
        Burst,
        PrimalBurst,
        Rage,
        Stance,
        DeviceKit,
        Elixir,
        Gadget,
        Gyro,
        ToolBelt,
        Turret,
        WeaponKit,
        CelestialAvatar,
        Pet,
        Spirit,
        Survival,
        Deception,
        StolenSkill,
        Trick,
        Venom,
        Arcane,
        Attunument,
        Cantrip,
        Conjure,
        Overload,
        Clone,
        Manipulation,
        Phantasm,
        Shatter,
        Corruption,
        Mark,
        Minion,
        Spectral
    }
}