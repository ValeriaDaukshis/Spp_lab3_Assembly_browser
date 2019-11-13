using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using InfoCollector.Containers;
using InfoCollector.MembersInfo;

namespace InfoCollector
{
    public class ClassInfo
    {
        private Type type;
        public ClassInfo(Type type)
        {
            this.type = type;
        }

        public Member GetTypeInfo()
        {
            MemberInfo[] members = type.GetMembers(BindingFlags.NonPublic
                                          | BindingFlags.Instance
                                          | BindingFlags.Public
                                          | BindingFlags.Static);

            foreach (var member in members)
            {
                string memberInfo = null;
                if (member.MemberType == MemberTypes.Property)
                {
                    memberInfo = new PropertyInfoClass((PropertyInfo)member).MemberInformation;
                }
                else if (member.MemberType == MemberTypes.Field)
                {
                    memberInfo = new FieldInfoClass((FieldInfo)member).MemberInformation;
                }
                else if (member.MemberType == MemberTypes.Event)
                {
                    memberInfo = new EventInfoClass((EventInfo)member).MemberInformation;
                }
                else if (member.MemberType == MemberTypes.Constructor)
                {
                    memberInfo = new ConstructorInfoClass((ConstructorInfo)member).MemberInformation;
                }

                if (memberInfo != null)
                {
                    string name = member.Name;
                    return new TypeInfoClass(name + memberInfo);
                }
            }

            return null;
        }
    }
}
