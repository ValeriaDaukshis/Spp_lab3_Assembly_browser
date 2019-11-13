using System.Text;
using System.Reflection;
using InfoCollector.Containers;

namespace InfoCollector
{
    public class FieldInfoClass : BaseInfoClass, Member
    {
        private FieldInfo info;

        public string Name { get; set; }
        
        public FieldInfoClass(FieldInfo info)
        {
            this.info = info;
            Name = GetFieldInfo(info);
        }

        protected string GetFieldInfo(FieldInfo field)
        {
            StringBuilder result = new StringBuilder();

            if (field.IsAssembly)
                result.Append("internal ");
            else if (field.IsFamily)
                result.Append("protected ");
            else if (field.IsFamilyOrAssembly)
                result.Append("protected internal ");
            else if (field.IsFamilyAndAssembly)
                result.Append("private protected ");
            else if (field.IsPrivate)
                result.Append("private ");
            else if (field.IsPublic)
                result.Append("public ");
            return result.ToString();
        }
    }
}