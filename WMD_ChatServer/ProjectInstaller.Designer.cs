//*********************************************
// File			 : ProjectInstaller.Designer.cs
// Project		 : PROG2121 - A6 Server as a Service
// Programmer	 : Nick Byam, Chris Lemon
// Last Change   : 2020-11-12
// Description	 : Automatically added code for the service installer
//*********************************************


namespace WMD_ChatServer
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WMD_ChatServerServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.WMD_ChatServerInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // WMD_ChatServerServiceProcessInstaller
            // 
            this.WMD_ChatServerServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.WMD_ChatServerServiceProcessInstaller.Password = null;
            this.WMD_ChatServerServiceProcessInstaller.Username = null;
            this.WMD_ChatServerServiceProcessInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceProcessInstaller1_AfterInstall);
            // 
            // WMD_ChatServerInstaller
            // 
            this.WMD_ChatServerInstaller.Description = "ChatServer for WMD";
            this.WMD_ChatServerInstaller.ServiceName = "WMD_ChatServer";
            this.WMD_ChatServerInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.serviceInstaller1_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.WMD_ChatServerServiceProcessInstaller,
            this.WMD_ChatServerInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller WMD_ChatServerServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller WMD_ChatServerInstaller;
    }
}