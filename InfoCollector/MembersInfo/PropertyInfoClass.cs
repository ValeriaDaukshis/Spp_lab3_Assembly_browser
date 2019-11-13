using System.Reflection;
using System.Text;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    public class PropertyInfoClass : BaseInfoClass, Member
    {
        private PropertyInfo info;

        public string Name { get; set; }

        public PropertyInfoClass(PropertyInfo info)
        {
            this.info = info;
            Name = GetPropertyInfo(info);
        }

        public string GetPropertyInfo(PropertyInfo propertyInfo)
        {
            StringBuilder result = new StringBuilder(GetTypeName(propertyInfo.PropertyType));
            result.Append(" ");
            result.Append(propertyInfo.Name);

            MethodInfo[] accessors = propertyInfo.GetAccessors(true);
            foreach (var accessor in accessors)
            {
                if (accessor.IsSpecialName)
                {
                    result.Append(" { ");
                    result.Append(accessor.Name);
                    result.Append(" } ");
                }
            }

            return result.ToString();
        }
    }
}
