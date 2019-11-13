using System.Collections.Generic;
using InfoCollector.MembersInfo;

namespace InfoCollector.Containers
{
    public class ContainerInfo
    {
        public List<Member> ClassificationElements { get; set; }
        public string Classification { get; set; }

        public void AddClassificationElement(Member element)
        {
            ClassificationElements.Add(element);
        }

        public ContainerInfo(string classification, List<Member> elements)
        {
            Classification = classification;
            ClassificationElements = elements;
        }

    }
}
