using LoginFormDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TAIS__Tourist_Agency_Info_System_
{
    internal static class Program
    {
        static void run(bool fl = false, AuthorizationLibrary.User? user = null)
        {
            if (fl == false)
            {
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    var users = loginForm.Users;
                    var username = loginForm.AuthenticatedUsername;

                    MessageBox.Show(username);
                    MessageBox.Show(string.Join(',', users));
                    /*MainForm mainForm = new MainForm(users[username]);
                    var dialog = mainForm.ShowDialog();
                    if (dialog == DialogResult.Continue)
                    {
                        ChangePassword changePassword = new ChangePassword(users[username]);
                        if (changePassword.ShowDialog() == DialogResult.OK)
                        {
                            run(false);
                        }
                        else
                        {
                            run(true, users[username]);
                        }
                    }
                    else if (dialog == DialogResult.Retry)
                    {
                        run(false);
                    }*/
                }
            }
            else
            {
                Console.WriteLine("123");
                /*MainForm mainForm = new MainForm(user);
                if (mainForm.ShowDialog() == DialogResult.Continue)
                {
                    ChangePassword changePassword = new ChangePassword(user);
                    if (changePassword.ShowDialog() == DialogResult.OK)
                    {
                        run(false);
                    }
                    else
                    {
                        run(true, user);
                    }
                }*/

            }
        }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            run();
        }
    }
}