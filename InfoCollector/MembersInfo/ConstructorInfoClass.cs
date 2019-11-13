using System.Reflection;
using InfoCollector.Containers;

namespace InfoCollector
{
    class ConstructorInfoClass : BaseInfoClass, Member
    {
        private ConstructorInfo constructorInfo;

        public string MemberInformation => GetConstructorInfo(constructorInfo);

        public ConstructorInfoClass(ConstructorInfo constructorInfo)
        {
            this.constructorInfo = constructorInfo;
        }

        private string GetConstructorInfo(ConstructorInfo constructorInfo)
        {
            return
                $"{GetMethodDeclaration(constructorInfo)} {GetMethodName(constructorInfo)} {GetParameters(constructorInfo.GetParameters())}";
        }
    }
}
