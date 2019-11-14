using System.Reflection;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    class ConstructorInfoClass : BaseInfoClass, Member
    {
        public string Name { get; set; }

        public ConstructorInfoClass(ConstructorInfo constructorInfo)
        {
            Name = GetConstructorInfo(constructorInfo);
        }

        private string GetConstructorInfo(ConstructorInfo constructorInfo)
        {
            return
                $"{GetMethodDeclaration(constructorInfo)} {GetMethodName(constructorInfo)} {GetParameters(constructorInfo.GetParameters())}";
        }
    }
}
