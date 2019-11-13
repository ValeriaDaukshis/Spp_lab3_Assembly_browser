using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoCollector.Containers
{
    public class ContainerInfo : Member
    {
        public List<Member> Members { get; set; }

        public ContainerInfo()
        {
            Members = new List<Member>();
        }

        public void AddMember(Member member)
        {
            Members.Add(member);
        }

        public string MemberInformation { get; }
    }
}
