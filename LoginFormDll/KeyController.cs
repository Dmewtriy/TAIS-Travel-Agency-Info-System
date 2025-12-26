using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWindow
{
    public class KeyController
    {

        public event EventHandler<string> CapsLockChanged;
        public event EventHandler<string> InputLanguageChanged;
        public event EventHandler<EventArgs> CloseRequested;
        public event EventHandler<EventArgs> EnterPressed;

        private bool _lastCapsState = Control.IsKeyLocked(Keys.CapsLock);

        // Метод для инициализации состояния при старте формы
        public void Initialize()
        {
            bool currentCapsState = Control.IsKeyLocked(Keys.CapsLock);
            string capsMessage = currentCapsState ? "Клавиша CapsLock нажата" : "Клавиша CapsLock не нажата";
            CapsLockChanged?.Invoke(this, capsMessage);

            var culture = InputLanguage.CurrentInputLanguage.Culture;
            string lang = culture.TwoLetterISOLanguageName.ToUpper();
            string langMessage = lang == "RU" ? "Язык ввода Русский" : "Язык ввода Английский";
            InputLanguageChanged?.Invoke(this, langMessage);
        }

        // Обработчик нажатия клавиш
        public void OnKeyDown(Keys key)
        {
            if (key == Keys.CapsLock)
            {
                bool currentState = Control.IsKeyLocked(Keys.CapsLock);
                if (currentState != _lastCapsState)
                {
                    _lastCapsState = currentState;
                    string statusMessage = currentState ? "Клавиша CapsLock нажата" : "Клавиша CapsLock не нажата";
                    CapsLockChanged?.Invoke(this, statusMessage);
                }
            }
            if (key == Keys.Escape)
            {
                CloseRequested?.Invoke(this, EventArgs.Empty);
            }
            else if (key == Keys.Enter)
            {
                EnterPressed?.Invoke(this, EventArgs.Empty);
            }
        }

        // Обработчик изменения языка ввода
        public void OnInputLanguageChanged()
        {
            var culture = InputLanguage.CurrentInputLanguage.Culture;
            string lang = culture.TwoLetterISOLanguageName.ToUpper();

            string res = lang == "RU" ? "Язык ввода Русский" : "Язык ввода Английский";
            InputLanguageChanged?.Invoke(this, res);
        }
    }
}
