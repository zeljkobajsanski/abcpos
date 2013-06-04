using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bootstrap;
using DevExpress.LookAndFeel;
using Bootstrap.AutoMapper;

namespace AbcPos.BackOffice.Win
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Bootstrapper.With.AutoMapper().Start();
            Application.Run(new Main());
        }
    }
}