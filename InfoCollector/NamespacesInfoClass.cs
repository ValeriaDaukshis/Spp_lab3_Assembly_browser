using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using InfoCollector.Containers;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class NamespacesInfoClass
    {
        private string path;
        public NamespacesInfoClass(string path)
        {
            this.path = path;
        }

        public ContainerInfo[] GetNamespaces()
        {
            var assembly = Assembly.LoadFile(path);
            var types = assembly.GetTypes();
            var namespaces = new Dictionary<string, ContainerInfo>();
            foreach (var type in types)
            {
                string typeNamespace = type.Namespace;
                if (typeNamespace == null) continue;
                ContainerInfo namespaceInfo;
                if (!namespaces.ContainsKey(typeNamespace))
                {
                    namespaceInfo = new NamespaceInfoClass(typeNamespace);
                    namespaces.Add(typeNamespace, namespaceInfo);
                }
                else
                {
                    namespaces.TryGetValue(typeNamespace, out namespaceInfo);
                }
                Member typeInfo = new ClassInfo(type).GetTypeInfo();
                namespaceInfo?.AddMember(typeInfo);
            }
            ContainerInfo[] result = namespaces.Values.ToArray();

            return result;
        }
    }
}
