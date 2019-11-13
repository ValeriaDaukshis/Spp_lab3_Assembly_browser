using System;
using System.Collections.Generic;
using System.Reflection;
using InfoCollector.Containers;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class ClassInfo : BaseInfoClass
    {
        private Type _type;

        public string Name { get; set; }

        public List<ContainerInfo> Elements { get; set; }

        public ClassInfo(Type type)
        {
            _type = type;
            Name = type.Name; //!!!!!!!!!
            Elements = new List<ContainerInfo>();
            AddElements();
            ScanFields();
            ScanProperties();
            ScanMethods();
        }

        public void AddElements()
        {
            Elements.Add(new ContainerInfo("Fields", new List<Member>()));
            Elements.Add(new ContainerInfo("Properties", new List<Member>()));
            Elements.Add(new ContainerInfo("Methods", new List<Member>()));
        }

        public void ScanFields()
        {
            FieldInfo[] fields = _type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (FieldInfo field in fields)
            {
                Elements[0].AddClassificationElement(new FieldInfoClass(field));
            }
        }

        public void ScanProperties()
        {
            PropertyInfo[] properties = _type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (PropertyInfo property in properties)
            {
                Elements[1].AddClassificationElement(new PropertyInfoClass(property));
            }
        }

        public void ScanMethods()
        {
            MethodInfo[] methods = _type.GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (MethodInfo method in methods)
            {
                if (!method.IsSpecialName)
                    Elements[2].AddClassificationElement(new MethodInfoClass(method));
            }
        }
    }
}
