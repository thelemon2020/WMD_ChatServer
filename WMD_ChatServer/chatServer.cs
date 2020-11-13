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
        Server myServer { get; set; }
        FileHandler fh;
        public chatServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myServer = new Server();
            fh = new FileHandler();
            Logger.Log(fh.eventLog, "Server Started");
        }

        protected override void OnStop()
        {
            myServer.repo.msgQueue.Enqueue("DISCONNECT,<EOF>");
            Logger.Log(fh.eventLog, "Server Stopped");
            Thread.Sleep(1000);
        }
    }
}
