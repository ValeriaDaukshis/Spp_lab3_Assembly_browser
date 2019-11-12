using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InfoCollector
{
    class EventInfoClass : BaseInfoClass
    {
        public string GetEventDeclaration(EventInfo eventInfo)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{GetTypeName(eventInfo.EventHandlerType)} {eventInfo.Name}");
            result.Append($" [{eventInfo.AddMethod.Name}] ");
            result.Append($" [{eventInfo.RemoveMethod.Name}] ");

            return result.ToString();
        }
    }
}
