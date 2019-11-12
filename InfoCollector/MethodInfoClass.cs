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
            var returnType = GetTypeName(methodInfo.ReturnType);
            var parameters = methodInfo.GetParameters();
            var declaration =
                    $"{GetMethodDeclaration(methodInfo)} {returnType} {GetMethodName(methodInfo)} {GetMethodParametersString(parameters)}";

                return declaration;
        }

        private string GetMethodName(MethodBase method)
        {

            if (method.IsGenericMethod)
            {
                return method.Name + GetGenericArgumentsString(method.GetGenericArguments());
            }
            return method.Name;
        }

        private string GetMethodDeclaration(MethodBase methodBase)
        {
            throw new System.NotImplementedException();
        }

        private string GetMethodParametersString(ParameterInfo[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
