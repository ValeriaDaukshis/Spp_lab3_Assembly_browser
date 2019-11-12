using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfoCollector
{
    public class MethodInfoClass : BaseInfoClass
    {
        public string GetMethodInfo(MethodInfo methodInfo)
        {
            string returnType = GetTypeName(methodInfo.ReturnType);
            ParameterInfo[] parameters = methodInfo.GetParameters();
            string declaration =
                    $"{GetMethodDeclaration(methodInfo)} {returnType} {GetMethodName(methodInfo)} {GetMethodParameters(parameters)}";

                return declaration;
        }

        private string GetMethodName(MethodInfo method)
        {
            if (method.IsGenericMethod)
            {
                return method.Name + GetGenericArgumentsString(method.GetGenericArguments());
            }
            return method.Name;
        }

        private string GetMethodParameters(ParameterInfo[] parameters)
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

        private string GetMethodDeclaration(MethodInfo method)
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
