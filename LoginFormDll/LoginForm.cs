using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoginFormDll
{
    public partial class LoginForm : Form
    {
        private string _prevLang = string.Empty;
        private bool _prevCaps;

        public LoginForm()
        {
            InitializeComponent();
            // ѕодписываемс€ на событи€ дл€ отслеживани€ смены €зыка ввода
            this.InputLanguageChanged += LoginForm_InputLanguageChanged;
            this.Activated += LoginForm_Activated;
            this.KeyDown += LoginForm_KeyDown; // ќбработка нажатий клавиш на форме

            // ”становим корректный начальный статус CapsLock сразу после инициализации компонентов
            bool initialCaps = Control.IsKeyLocked(Keys.CapsLock);
            statusRight.Text = initialCaps ? " лавиша CapsLock нажата" : " лавиша CapsLock не нажата";
            _prevCaps = initialCaps;

            // »нициалный апдейт
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

            // CapsLock: обновл€ем статус (вызов через BeginInvoke чтобы состо€ние клавиши уже успело изменитьс€)
            if (e.KeyCode == Keys.CapsLock)
            {
                BeginInvoke((Action)UpdateCapsLockStatus);
                // не подавл€ем, чтобы система обработала переключение
            }

            // Enter: выполнить попытку входа (нажать кнопку ќ )
            if (e.KeyCode == Keys.Enter)
            {
                // ¬ыполн€ем клик кнопки входа
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
                    case "ru": display = "язык ввода: –усский"; break;
                    case "en": display = "язык ввода: јнглийский"; break;
                    case "fr": display = "язык ввода: ‘ранцузский"; break;
                    case "de": display = "язык ввода: Ќемецкий"; break;
                    case "es": display = "язык ввода: »спанский"; break;
                    default:
                        var name = InputLanguage.CurrentInputLanguage?.Culture?.EnglishName ?? "";
                        display = $"язык ввода: {name}";
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
                // »гнорируем ошибки определени€ €зыка
            }
        }

        private void UpdateCapsLockStatus()
        {
            bool caps = Control.IsKeyLocked(Keys.CapsLock);
            if (caps != _prevCaps)
            {
                statusRight.Text = caps ? " лавиша CapsLock нажата" : " лавиша CapsLock не нажата";
                _prevCaps = caps;
            }
        }

        private void OkButton_Click(object? sender, EventArgs e)
        {
            MessageBox.Show($"User: {userText.Text}\nPass: {new string('*', passText.Text.Length)}", "¬ход", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
