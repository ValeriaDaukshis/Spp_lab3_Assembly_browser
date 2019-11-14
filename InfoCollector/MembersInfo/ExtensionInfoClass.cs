using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    public class ExtensionInfoClass : BaseInfoClass, Member
    {
        public string Name { get; set; }

        public ExtensionInfoClass(MethodInfo info)
        {
            Name = $"extension {GetMethodInfo(info)}";
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
