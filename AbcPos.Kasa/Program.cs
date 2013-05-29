using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AbcPos.Core.Repository;
using AbcPos.Kasa.Forms;
using DevExpress.LookAndFeel;
using DevExpress.Xpo.Logger;
using DevExpress.XtraExport;
using LogManager = NLog.LogManager;

namespace AbcPos.Kasa
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var log = LogManager.GetCurrentClassLogger();
            log.Info("ABC Pos startuje");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.UserSkins.BonusSkins.Register();
            UserLookAndFeel.Default.SetSkinStyle("Metropolis");

            Application.Run(new Shell());

            Application.ThreadException += (s, e) =>
            {
                log.ErrorException("Neobrađena greška", e.Exception);
                Shell.ShowError(e.Exception.Message);
            };
        }
    }
}