using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using InfoCollector.Containers;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class ClassInfo : BaseInfoClass
    {
        private Type _type;
        private Assembly assembly;

        public string Name { get; set; }

        public List<ContainerInfo> Elements { get; set; }

        public ClassInfo(Type type, Assembly assembly)
        {
            _type = type;
            Name = new TypeInfoClass(type).Name + type.Name;
            Elements = new List<ContainerInfo>();
            this.assembly = assembly;
            AddElements();

            ScanFields();
            ScanProperties();
            ScanMethods();
            ScanConstructors();
            ScanExtensions();
        }

        public void AddElements()
        {
            Elements.Add(new ContainerInfo("Fields", new List<Member>()));
            Elements.Add(new ContainerInfo("Properties", new List<Member>()));
            Elements.Add(new ContainerInfo("Methods", new List<Member>()));
            Elements.Add(new ContainerInfo("Constructors", new List<Member>()));
            Elements.Add(new ContainerInfo("Extension methods", new List<Member>()));
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
                Elements[2].AddClassificationElement(new MethodInfoClass(method));
            }
        }

        public void ScanConstructors()
        {
            ConstructorInfo[] constructorInfos = _type.GetConstructors(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (ConstructorInfo method in constructorInfos)
            {
                Elements[3].AddClassificationElement(new ConstructorInfoClass(method));
            }
        }

        public void ScanExtensions()
        {
            var constructorInfos =  from type in assembly.GetTypes()
                where type.IsSealed && !type.IsGenericType && !type.IsNested
                from method in type.GetMethods(BindingFlags.Static
                                               | BindingFlags.Public | BindingFlags.NonPublic)
                where method.IsDefined(typeof(ExtensionAttribute), false)
                select method;

            foreach (var method in constructorInfos)
            {
                Elements[4].AddClassificationElement(new ExtensionInfoClass(method));
            }
        }
    }
}
