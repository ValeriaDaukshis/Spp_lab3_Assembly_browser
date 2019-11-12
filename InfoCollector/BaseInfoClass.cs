using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfoCollector
{
    public class BaseInfoClass
    {
        protected string GetTypeName(Type type)
        {
            string result = $"{type.Namespace}.{type.Name}";
            if (type.IsGenericType)
            {
                result += GetGenericArgumentsString(type.GetGenericArguments());
            }
            return result;
        }

        protected string GetGenericArgumentsString(Type[] arguments)
        {
            StringBuilder genericArgumentsString = new StringBuilder("<");
            for (int i = 0; i < arguments.Length; i++)
            {
                genericArgumentsString.Append(GetTypeName(arguments[i]));
                if (i != arguments.Length - 1)
                {
                    genericArgumentsString.Append(", ");
                }
            }
            genericArgumentsString.Append(">");

            return genericArgumentsString.ToString();
        }
    }
}
