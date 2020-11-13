//*********************************************
// File			 : Logger.cs
// Project		 : PROG2121 - A6 Server as a Service
// Programmer	 : Nick Byam, Chris Lemon
// Last Change   : 2020-11-13
// Description	 : A static Logger class used to log service events to the event log. It is also used as the standard interface for all file
//				 : writing whether that is the registration log, or the client log that details which ports are in use.
//*********************************************


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WMD_ChatServer
{
    //******************************************
    // Name     : Logger
    // Purpose  : A static class which exposes a log method to write timestamped strings to the specified path.
    //******************************************
    public static class Logger
    {

        private static readonly object obj = new object(); // an object used with the lock keyword to make write access thread safe


        /////////////////////////////////////////
        // Method       : Log
        // Description  : A method that takes a specified string, timestamps it, and then writes it to the specified path
        // Parameters   : string path : the path to the file to write to
        //              : string msg : The string to be timestamped and written to the specified path
        // Returns      : N/A
        /////////////////////////////////////////
        public static void Log(string path, string msg)
        {
            // Get current eastern standard time
            string timeStamp = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).ToString();
            // Add the timestamp to the specified string, and then add a carriage return
            string logString = timeStamp + " - " + msg + "\n";
            // Lock the obj object to make the write thread safe.
            lock (obj)
            {
                try
                {
                    if(msg == "") // If the clear client log method is called, then change the logger so it clears the client log rather than appends
                    {
                        File.WriteAllText(path, msg);
                    }
                    else // if the clear client log method was not called then just append to the text file like normal
                    {
                        File.AppendAllText(path, logString);
                    }    
                    
                }
                catch (IOException e) // in case of a write exception
                {
                    EventLog serverEventLog = new EventLog(); // create an EventLog class
                    if(!EventLog.SourceExists("ChatServerEventSource")) // create the source if it doesn't yet exist
                    {
                        EventLog.CreateEventSource("ChatServerEventSource", "ChatServerEvents");
                    } // Write the exception to the event log in case the logger can't write to the text log
                    serverEventLog.Source = "ChatSeverEventSource";
                    serverEventLog.Log = "ChatServerEvents";
                    serverEventLog.WriteEntry(e.Message);
                }
            }
        }
    }
}
