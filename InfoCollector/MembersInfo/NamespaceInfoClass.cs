using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    public class NamespaceInfoClass : ContainerInfo, Member
    {
        private string name;

        public string MemberInformation => $"namespace {name}";

        public NamespaceInfoClass(string name)
        {
            this.name = name;
        }
    }
}
