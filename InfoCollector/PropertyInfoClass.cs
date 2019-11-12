using System.Reflection;
using System.Text;

namespace InfoCollector
{
    public class PropertyInfoClass : BaseInfoClass
    {
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
