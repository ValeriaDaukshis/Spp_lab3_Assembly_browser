using System;
using System.Reflection;
using System.Text;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    public class PropertyInfoClass : BaseInfoClass, Member
    {
        public string Name { get; set; }

        public PropertyInfoClass(PropertyInfo info)
        {
            Name = GetPropertyInfo(info);
        }

        public string GetPropertyInfo(PropertyInfo propertyInfo)
        {
            StringBuilder result = new StringBuilder(GetTypeName(propertyInfo.PropertyType));
            result.Append(" ");
            result.Append(propertyInfo.Name);

            MethodInfo[] accessors = propertyInfo.GetAccessors();
            foreach (var accessor in accessors)
            {
                result.Append(" { ");
                result.Append(accessor.Name.StartsWith("get") ? "get;" : "set;");
                result.Append(" } ");
            }

            return result.ToString();
        }
    }
}
