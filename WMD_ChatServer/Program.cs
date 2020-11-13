//*********************************************
// File			 : Program.cs
// Project		 : PROG2121 - A6 Server as a Service
// Programmer	 : Nick Byam, Chris Lemon
// Last Change   : 2020-11-12
// Description	 : Service main that creates the server service to be run.
//*********************************************


using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WMD_ChatServer
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new chatServer()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
