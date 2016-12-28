using System;

namespace GuildWars2.Models.JSON
{
    public class EnumName : Attribute
    {
        public string Text { get; set; }

        public EnumName(string text)
        {
            Text = text;
        }
    }
}
