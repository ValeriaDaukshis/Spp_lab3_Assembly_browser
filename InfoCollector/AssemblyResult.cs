using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class AssemblyResult
    {
        public List<NamespaceInfoClass> Namespaces { get; set; }


        public AssemblyResult()
        {
            Namespaces = new List<NamespaceInfoClass>();
        }

        public void AddNamespace(NamespaceInfoClass namespaceInfo)
        {
            Namespaces.Add(namespaceInfo);
        }

        public NamespaceInfoClass FindNamespace(string name)
        {
            name = "namespace " + name;
            return Namespaces.Find(x => x.Name == name);
        }

        public void Clear()
        {
            Namespaces.Clear();
        }
    }
}
