using AuthorizationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginWindow
{
    public class ChangePasswordController
    {
        private ChangePassword view;
        private User user;

        public ChangePasswordController(ChangePassword changePassForm, User user)
        {
            view = changePassForm;
            this.user = user;
        }

        public bool AuthorizationData()
        {
            // Создаем объект авторизации
            var auth = new Authorization();

            // Тестовая авторизация
            string oldPassword = view.GetOldPassword();
            string newPassword = view.GetNewPassword();
            string acceptPassword = view.GetAcceptPassword();

            if (auth.Authenticate(user.UserName, oldPassword))
            {
                if (newPassword != acceptPassword) throw new Exception("Неверное подтверждение пароля.");
                else if (newPassword == oldPassword)
                {
                    throw new Exception("Новый и старый пароль одинаковы.");
                }
                auth.ChangePassword(user.UserName, newPassword);
                return true;
            }
            else
            {
                throw new Exception("Неверный старый пароль.");
            }
        }
    }
}
