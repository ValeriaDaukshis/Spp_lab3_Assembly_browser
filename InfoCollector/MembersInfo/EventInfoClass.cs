﻿using System.Reflection;
using System.Text;
using InfoCollector.Containers;

namespace InfoCollector
{
    class EventInfoClass : BaseInfoClass, Member
    {
        private EventInfo eventInfo;
        public string MemberInformation => GetEventDeclaration(eventInfo);

        public EventInfoClass(EventInfo eventInfo)
        {
            this.eventInfo = eventInfo;
        }

        private string GetEventDeclaration(EventInfo eventInfo)
        {
            StringBuilder result = new StringBuilder();
            result.Append($"{GetTypeName(eventInfo.EventHandlerType)} {eventInfo.Name}");
            result.Append($" [{eventInfo.AddMethod.Name}] ");
            result.Append($" [{eventInfo.RemoveMethod.Name}] ");

            return result.ToString();
        }
    }
}