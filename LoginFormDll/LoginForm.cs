using AuthorizationLibrary;
using LoginWindow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginFormDll
{
    public partial class LoginForm : Form
    {
        private string _prevLang = string.Empty;
        private bool _prevCaps;
        private LoginController loginController;

        public LoginForm()
        {
            InitializeComponent();
            // Подписываемся на события для отслеживания смены языка ввода
            this.InputLanguageChanged += LoginForm_InputLanguageChanged;
            this.Activated += LoginForm_Activated;
            this.KeyDown += LoginForm_KeyDown; // Обработка нажатий клавиш на форме
            loginController = new LoginController(this);
            // Установим корректный начальный статус CapsLock сразу после инициализации компонентов
            bool initialCaps = Control.IsKeyLocked(Keys.CapsLock);
            statusRight.Text = initialCaps ? "Клавиша CapsLock нажата" : "Клавиша CapsLock не нажата";
            _prevCaps = initialCaps;

            // Инициалный апдейт
            UpdateInputLanguageStatus();
            // не нужно вызывать UpdateCapsLockStatus() здесь, так как статус уже установлен
        }

        private void LoginForm_Activated(object? sender, EventArgs e)
        {
            UpdateInputLanguageStatus();
            UpdateCapsLockStatus();
        }

        private void LoginForm_InputLanguageChanged(object? sender, InputLanguageChangedEventArgs e)
        {
            UpdateInputLanguageStatus();
        }

        private void LoginForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e == null) return;

            // CapsLock: обновляем статус (вызов через BeginInvoke чтобы состояние клавиши уже успело измениться)
            if (e.KeyCode == Keys.CapsLock)
            {
                BeginInvoke((Action)UpdateCapsLockStatus);
                // не подавляем, чтобы система обработала переключение
            }

            // Enter: выполнить попытку входа (нажать кнопку ОК)
            if (e.KeyCode == Keys.Enter)
            {
                // Выполняем клик кнопки входа
                okButton.PerformClick();
                e.SuppressKeyPress = true; // предотвратить звук/дальнейшую обработку
            }
        }

        private void UpdateInputLanguageStatus()
        {
            try
            {
                var lang = InputLanguage.CurrentInputLanguage?.Culture?.TwoLetterISOLanguageName ?? string.Empty;
                string display;
                switch (lang)
                {
                    case "ru": display = "Язык ввода: Русский"; break;
                    case "en": display = "Язык ввода: Английский"; break;
                    case "fr": display = "Язык ввода: Французский"; break;
                    case "de": display = "Язык ввода: Немецкий"; break;
                    case "es": display = "Язык ввода: Испанский"; break;
                    default:
                        var name = InputLanguage.CurrentInputLanguage?.Culture?.EnglishName ?? "";
                        display = $"Язык ввода: {name}";
                        break;
                }

                if (display != _prevLang)
                {
                    statusLeft.Text = display;
                    _prevLang = display;
                }
            }
            catch
            {
                // Игнорируем ошибки определения языка
            }
        }

        private void UpdateCapsLockStatus()
        {
            bool caps = Control.IsKeyLocked(Keys.CapsLock);
            if (caps != _prevCaps)
            {
                statusRight.Text = caps ? "Клавиша CapsLock нажата" : "Клавиша CapsLock не нажата";
                _prevCaps = caps;
            }
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            try
            {
                if (loginController.AuthorizationData())
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

        public string GetName()
        {
            return userText.Text;
        }

        public string GetPassword()
        {
            return passText.Text;
        }

        public string AuthenticatedUsername
        {
            get { return loginController.AuthenticatedUsername; }
        }

        public Dictionary<string, User> Users
        {
            get { return loginController.users; }
        }

    }
}
