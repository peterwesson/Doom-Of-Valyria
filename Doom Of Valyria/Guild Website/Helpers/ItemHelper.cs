using System.Text.RegularExpressions;

namespace GuildWebsite.Helpers
{
    public static class ItemHelper
    {
        public static string StripHTML(string input)
        {
            return Regex.Replace(input ?? string.Empty, "<.*?>", string.Empty);
        }
    }
}