using AuthorizationLibrary;
using LoginWindow;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginWindow
{
    public partial class ChangePassword : Form
    {
        private const string version = "1.0.0.5";
        private ChangePasswordController changePasswordController;
        private KeyController _keyController;

        public ChangePassword(User user)
        {
            InitializeComponent();
            versionLabel.Text = $"Версия: {version}";

            changePasswordController = new ChangePasswordController(this, user);
            _keyController = new KeyController();

            _keyController.CapsLockChanged += OnCapsLockChanged;
            _keyController.InputLanguageChanged += OnInputLanguageChanged;
            _keyController.EnterPressed += AcceptButton_Click;
            _keyController.CloseRequested += CancelButton_Click;

            _keyController.Initialize();
        }
        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            _keyController.OnKeyDown(e.KeyCode);
        }

        private void Form_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            _keyController.OnInputLanguageChanged();
        }

        private void OnCapsLockChanged(object sender, string statusMessage)
        {
            capsLockLabel.Text = statusMessage;
        }

        private void OnInputLanguageChanged(object sender, string lang)
        {
            languageLabel.Text = lang;
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (changePasswordController.AuthorizationData())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        public string GetOldPassword()
        {
            return oldPasswordTextBox.Text;
        }

        public string GetNewPassword()
        {
            return newPasswordTextBox.Text;
        }

        public string GetAcceptPassword()
        {
            return acceptPasswordTextBox.Text;
        }

        /*
        public string AuthenticatedUsername
        {
            get { return changePasswordController.ChangedPasswordUsername; }
        }

        public Dictionary<string, User> Users
        {
            get { return changePasswordController.users; }
        }
        */
    }
}
