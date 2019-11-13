using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfoCollector.Containers;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class AssemblyBrowser
    {
        public AssemblyResult GetNamespaces(string path)
        {
            AssemblyResult _result = new AssemblyResult();
            Type[] types;
            NamespaceInfoClass searchResult;

            Assembly _asm = Assembly.LoadFrom(path);
            types = _asm.GetTypes();
            _result.Clear();
            foreach (var type in types)
            {
                searchResult = _result.FindNamespace(type.Namespace);
                if (searchResult == null)
                {
                    searchResult = new NamespaceInfoClass(type.Namespace);
                    _result.AddNamespace(searchResult);
                }
                searchResult.AddClass(new ClassInfo(type));
            }
            return _result;
        }
    }
}
