using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WMD_ChatServer
{
    public static class Logger
    {

        private static readonly object obj = new object();
        public static void Log(string path, string msg)
        {
            string timeStamp = DateTime.UtcNow.ToString();
            string logString = timeStamp + " - " + msg + "\n";
            lock (obj)
            {
                try
                {
                    if(msg == "") // If the clear client log method is called, then change the logger so it clears the client log rather than appends
                    {
                        File.WriteAllText(path, msg);
                    }
                    else
                    {
                        File.AppendAllText(path, logString);
                    }    
                    
                }
                catch (IOException e)
                {
                    EventLog serverEventLog = new EventLog();
                    if(!EventLog.SourceExists("ChatServerEventSource"))
                    {
                        EventLog.CreateEventSource("ChatServerEventSource", "ChatServerEvents");
                    }
                    serverEventLog.Source = "ChatSeverEventSource";
                    serverEventLog.Log = "ChatServerEvents";
                    serverEventLog.WriteEntry(e.Message);
                }
            }
        }
    }
}
