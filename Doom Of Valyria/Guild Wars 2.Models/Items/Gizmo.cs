using Newtonsoft.Json;

namespace GuildWars2.Models.Items
{
    public class Gizmo : Item
    {
        [JsonProperty("subtype")]
        public GizmoType GizmoType { get; set; }
    }
}