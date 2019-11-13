using System;
using System.Reflection;
using System.Text;

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

        protected string GetParameters(ParameterInfo[] parameters)
        {
            StringBuilder parametersString = new StringBuilder("(");
            for (int i = 0; i < parameters.Length; i++)
            {
                parametersString.Append(GetTypeName(parameters[i].ParameterType));
                if (i != parameters.Length - 1)
                {
                    parametersString.Append(", ");
                }
            }
            parametersString.Append(")");

            return parametersString.ToString();
        }

        protected string GetMethodName(MethodBase method)
        {
            if (method.IsGenericMethod)
            {
                return method.Name + GetGenericArgumentsString(method.GetGenericArguments());
            }
            return method.Name;
        }

        protected string GetMethodDeclaration(MethodBase method)
        {
            StringBuilder result = new StringBuilder();

            if (method.IsAssembly)
                result.Append("internal ");
            else if (method.IsFamily)
                result.Append("protected ");
            else if (method.IsFamilyOrAssembly)
                result.Append("protected internal ");
            else if (method.IsFamilyAndAssembly)
                result.Append("private protected ");
            else if (method.IsPrivate)
                result.Append("private ");
            else if (method.IsPublic)
                result.Append("public ");
            return result.ToString();
        }
    }
}
