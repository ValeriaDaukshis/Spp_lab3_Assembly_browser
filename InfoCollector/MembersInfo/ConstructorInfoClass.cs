using System.Reflection;
using InfoCollector.Containers;

namespace InfoCollector
{
    class ConstructorInfoClass : BaseInfoClass, Member
    {
        private ConstructorInfo constructorInfo;

        public string Name { get; set; }

        public ConstructorInfoClass(ConstructorInfo constructorInfo)
        {
            this.constructorInfo = constructorInfo;
            Name = $"constructor {GetConstructorInfo(constructorInfo)}";
        }

        private string GetConstructorInfo(ConstructorInfo constructorInfo)
        {
            return
                $"{GetMethodDeclaration(constructorInfo)} {GetMethodName(constructorInfo)} {GetParameters(constructorInfo.GetParameters())}";
        }
    }
}
