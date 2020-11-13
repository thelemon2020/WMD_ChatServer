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
    public partial class chatServer : ServiceBase
    {
        public Server myServer { get; set; }
        public FileHandler fh { get; set; }
        public Thread listenerThread { get; set; }
        public chatServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myServer = new Server();
            fh = new FileHandler();
            ThreadStart listenerThreadStart = new ThreadStart(myServer.startListener);
            listenerThread = new Thread(listenerThreadStart);
            listenerThread.Start();            
            Logger.Log(fh.eventLog, "Server Started");
        }

        protected override void OnStop()
        {
            myServer.repo.msgQueue.Enqueue("DISCONNECT,<EOF>");
            Logger.Log(fh.eventLog, "Server Stopped");
            myServer.manager.run = false;
            listenerThread.Join();
        }
    }
}
