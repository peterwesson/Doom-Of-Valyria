using System;

using GuildWars2.Models.JSON;

namespace GuildWebsite.Helpers
{
    public class CustomEnumHelper
    {
        public static string GetEnumName(Enum enumValue)
        {
            var type = enumValue.GetType();

            var memInfo = type.GetMember(enumValue.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                var attributes = memInfo[0].GetCustomAttributes(typeof(EnumName), false);

                if (attributes != null && attributes.Length > 0)

                    return ((EnumName)attributes[0]).Text;
            }

            return enumValue.ToString();
        }
    }
}