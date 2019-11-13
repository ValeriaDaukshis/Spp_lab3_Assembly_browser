using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class AssemblyInfo
    {
        public string Name { get; set; }
        private List<EventInfoClass> eventInfo;
        private List<PropertyInfoClass> propertyInfo;
        private List<MethodInfoClass> methodInfo;
        private List<FieldInfoClass> fieldInfo;
        private List<ConstructorInfoClass> constructorInfo;

        private BaseInfoClass baseInfo;

        public AssemblyInfo(BaseInfoClass baseInfo)
        {
            this.baseInfo = baseInfo;
        }
    }
}
