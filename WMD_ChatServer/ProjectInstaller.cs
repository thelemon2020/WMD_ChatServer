//*********************************************
// File			 : ProjectInstaller.cs
// Project		 : PROG2121 - A6 Server as a Service
// Programmer	 : Nick Byam, 8656317
// Last Change   : 2020-11-12
// Description	 : Automatically added code that is used to install the service
//*********************************************


using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

namespace WMD_ChatServer
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void serviceProcessInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }

        private void serviceInstaller1_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
