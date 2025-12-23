using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using LoginFormDll;

namespace TAIS__Tourist_Agency_Info_System_
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            using var login = new LoginForm();
            var dr = login.ShowDialog();
            if (dr != DialogResult.OK) return;

            Application.Run(new MainForm());
        }
    }
}