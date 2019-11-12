using System.Reflection;

namespace InfoCollector
{
    class ConstructorInfoClass : BaseInfoClass
    {
        private string GetConstructorInfo(ConstructorInfo constructorInfo)
        {
            return
                $"{GetMethodDeclaration(constructorInfo)} {GetMethodName(constructorInfo)} {GetParameters(constructorInfo.GetParameters())}";
        }
    }
}
