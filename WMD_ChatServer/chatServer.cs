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
        public chatServer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            myServer = new Server();
            Logger.Log("Server has started");
        }

        protected override void OnStop()
        {
            myServer.repo.msgQueue.Enqueue("DISCONNECT,<EOF>");
            Thread.Sleep(1000);
            Logger.Log("Server Shut Down");
        }
    }
}
