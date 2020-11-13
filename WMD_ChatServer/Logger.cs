using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMD_ChatServer
{
    public static class Logger
    {
        public static void Log(string logString)
        {
            EventLog myLogFile = new EventLog();
            if (!EventLog.SourceExists("ChatServerSource"))
            {
                EventLog.CreateEventSource("ChatServerSource", "ChatServerLog");
            }
            myLogFile.Source = "ChatServerSource";
            myLogFile.Log = "ChatServerLog";
            myLogFile.WriteEntry(logString);
        }
    }
}
