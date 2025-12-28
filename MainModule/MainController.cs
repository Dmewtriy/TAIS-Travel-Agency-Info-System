using LoginFormDll;
using System;
using System.Windows.Forms;
using HelpModule;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using EmployeeModule;

namespace TAIS__Tourist_Agency_Info_System_
{
    internal static class Program
    {
        static void run(bool fl = false, AuthorizationLibrary.User? user = null)
        {
            InitRepos initRepos = new InitRepos();
            if (fl == false)
            {
                EmployeeForm loginForm = new EmployeeForm(initRepos, 0);
                if (loginForm.ShowDialog() == DialogResult.OK)
                {

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