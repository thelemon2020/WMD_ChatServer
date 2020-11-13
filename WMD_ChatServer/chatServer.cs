//*********************************************
// File			 : chatServer.cs
// Project		 : PROG2121 - A6 Server as a Service
// Programmer	 : Nick Byam, Chris Lemon
// Last Change   : 2020-11-13
// Description	 : chatServer code behind that describes the OnStart and OnStop service event handlers.
//*********************************************


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WMD_ChatServer
{
    //******************************************
    // Name     : chatServer
    // Purpose  : A service class inheriting from the ServiceBase class. This class is added to the servicesToRun array and run when the
    //          : when the service is manually started
    //******************************************
    public partial class chatServer : ServiceBase
    {
        public Server myServer { get; set; }
        public FileHandler fh { get; set; }
        public Thread listenerThread { get; set; }

        /////////////////////////////////////////
        // Method       : chatServer (ctor)
        // Description  : Initializes the class to be run
        // Parameters   : N/A
        // Returns      : N/A
        /////////////////////////////////////////
        public chatServer()
        {
            InitializeComponent();
        }


        /////////////////////////////////////////
        // Method       : OnStart
        // Description  : The start service event handler. Spins up a thread for the server to run on and then logs that server has started.
        // Parameters   : string[] args : arguments for the event handler, unused as of now
        // Returns      : N/A
        /////////////////////////////////////////
        protected override void OnStart(string[] args)
        {
            myServer = new Server();
            fh = new FileHandler();
            ThreadStart listenerThreadStart = new ThreadStart(myServer.startListener);
            listenerThread = new Thread(listenerThreadStart);
            listenerThread.Start();            
            Logger.Log(fh.eventLog, "Server Started");
        }


        /////////////////////////////////////////
        // Method       : OnStop
        // Description  : The stop service event handler. Shuts down the server functionality and disconnects all clients before stopping the listener
        // Parameters   : N/A
        // Returns      : N/A
        /////////////////////////////////////////
        protected override void OnStop()
        {
            myServer.repo.msgQueue.Enqueue("DISCONNECT,<EOF>");
            Logger.Log(fh.eventLog, "Server Stopped");
            myServer.manager.run = false;
            listenerThread.Join();
        }
    }
}
