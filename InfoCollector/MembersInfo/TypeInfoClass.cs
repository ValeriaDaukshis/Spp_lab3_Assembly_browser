using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.Containers;

namespace InfoCollector.MembersInfo
{
    public class TypeInfoClass : Member
    {
        private string info;

        public string Name { get; set; }

        public TypeInfoClass(string info)
        {
            this.info = info;
            Name = $"class {info}";
        }
    }
}
