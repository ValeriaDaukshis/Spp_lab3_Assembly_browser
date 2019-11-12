using System;
using System.Text;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace InfoCollector
{
    public class FieldInfoClass : BaseInfoClass
    {
        public string GetFieldInfo(FieldInfo fieldInfo)
        {
            var result = new StringBuilder();
            // add logic of class type

            result.Append(GetTypeName(fieldInfo.FieldType));
            result.Append(" ");
            result.Append(fieldInfo.Name);

            return result.ToString();
        }
    }
}