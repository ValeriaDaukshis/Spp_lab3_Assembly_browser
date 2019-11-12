using System.Reflection;
using System.Text;

namespace InfoCollector
{
    public class MethodInfoClass : BaseInfoClass
    {
        public string GetMethodInfo(MethodInfo methodInfo)
        {
            string returnType = GetTypeName(methodInfo.ReturnType);
            ParameterInfo[] parameters = methodInfo.GetParameters();
            string declaration =
                    $"{GetMethodDeclaration(methodInfo)} {returnType} {GetMethodName(methodInfo)} {GetParameters(parameters)}";

                return declaration;
        }
    }
}
