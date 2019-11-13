using System.Reflection;
using System.Text;
using InfoCollector.Containers;

namespace InfoCollector
{
    public class MethodInfoClass : BaseInfoClass, Member
    {
        private MethodInfo info;

        public string MemberInformation => GetMethodInfo(info);

        public MethodInfoClass(MethodInfo info)
        {
            this.info = info;
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
