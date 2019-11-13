using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    public class NamespaceInfoClass
    {
        public string Name { get; set; }

        public List<ClassInfo> Classes { get; set; }

        public NamespaceInfoClass(string name)
        {
            Name = "namespace " + name;
            Classes = new List<ClassInfo>();
        }

        public void AddClass(ClassInfo classInfo)
        {
            Classes.Add(classInfo);
        }
    }
}
