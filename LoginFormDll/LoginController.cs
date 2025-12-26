using AuthorizationLibrary;
using LoginFormDll;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Net;

namespace LoginWindow
{
    public class LoginController
    {
        private LoginForm view;
        private string _authenticatedUsername;
        private Dictionary<string, AuthorizationLibrary.User> _users;
        public Dictionary<string, AuthorizationLibrary.User> users { get { return _users; } }
        public string AuthenticatedUsername { get { return _authenticatedUsername; } }

        public LoginController(LoginFormDll.LoginForm loginForm)
        {
            view = loginForm;
        }

        public bool AuthorizationData()
        {
            // Создаем объект авторизации
            var auth = new AuthorizationLibrary.Authorization();
            _users = auth.users;
            // Тестовая авторизация
            string username = view.GetName();
            string password = view.GetPassword();

            if (auth.Authenticate(username, password))
            {
                _authenticatedUsername = username;
                return true;
            }
            else
            {
                throw new Exception("Неверное имя пользователя или пароль.");
            }
        }
    }
}