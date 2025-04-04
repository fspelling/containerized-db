using System.ComponentModel;
using System.Reflection;

namespace ContainerizedDB.Domain.Extensions
{
    public static class EnumExtension
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString())!;
            var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute))!;

            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
