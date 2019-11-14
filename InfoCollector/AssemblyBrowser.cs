using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class AssemblyBrowser
    {
        public AssemblyResult GetNamespaces(string path)
        {
            AssemblyResult result = new AssemblyResult();
            Type[] types;
            NamespaceInfoClass searchResult;

            Assembly assembly = Assembly.LoadFrom(path);
            types = assembly.GetTypes();
            foreach (var type in types)
            {
                searchResult = result.FindNamespace(type.Namespace);
                if (searchResult == null)
                {
                    searchResult = new NamespaceInfoClass(type.Namespace);
                    result.AddNamespace(searchResult);
                }
                searchResult.AddClass(new ClassInfo(type, assembly));
            }
            return result;
        }
    }
}
