using Newtonsoft.Json;

namespace GuildWars2.Models.Account
{
    public enum Permissions
    {
        [JsonProperty("account")]
        Account,
        [JsonProperty("builds")]
        Builds,
        [JsonProperty("characters")]
        Characters,
        [JsonProperty("guilds")]
        Guilds,
        [JsonProperty("inventories")]
        Inventories,
        [JsonProperty("progression")]
        Progression,
        [JsonProperty("pvp")]
        PvP,
        [JsonProperty("tradingpost")]
        TradingPost,
        [JsonProperty("unlocks")]
        Unlocks,
        [JsonProperty("wallet")]
        Wallet
    }
}