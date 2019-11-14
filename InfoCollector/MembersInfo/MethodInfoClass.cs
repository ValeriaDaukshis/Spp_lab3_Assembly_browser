using System.Reflection;
using System.Text;
using InfoCollector.Containers;

namespace InfoCollector
{
    public class MethodInfoClass : BaseInfoClass, Member
    {
        public string Name { get; set; }

        public MethodInfoClass(MethodInfo info)
        {
            Name = GetMethodInfo(info);
        }

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
