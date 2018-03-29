using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Markup;

namespace KimzWpfCommon.MarkupExtensions
{
    [MarkupExtensionReturnType(typeof(EventLogEntry))]
    public class EventLogMarkup : MarkupExtension
    {        
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            List<EventLogEntry> eventList = new List<EventLogEntry>();

            EventLog myEventLog = new EventLog("System", ".");
            EventLogEntryCollection myLogEntryCollection = myEventLog.Entries;
            int myCount = myLogEntryCollection.Count;

            for (var i = myCount - 1; i > 0; i--)
            {
                EventLogEntry myLogEntry = myLogEntryCollection[i];
                eventList.Add(myLogEntry);
            }

            return eventList;
        }
    }
}
