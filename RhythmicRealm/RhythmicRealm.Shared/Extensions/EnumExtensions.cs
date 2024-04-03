using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace RhythmicRealm.Shared.Extensions
{
	public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
           string result = value
                .GetType()
                .GetMember(value.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                ?.GetName();
            return result;
        }
    }
}
