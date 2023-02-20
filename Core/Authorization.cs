using _20101_Savrikov_authorization.Model;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _20101_Savrikov_authorization.Core
{
    public class ForAuthorization
    {
        public void GetAuthorization(string login, string password)
        {
            UsersRolesBaseEntities db = UsersRolesBaseEntities.GetContext();

            if (db.User.Any(u => u.login == login && u.password == password))
            {
                var user = db.User.Where(u => u.login == login && u.password == password).FirstOrDefault();
                int idRole = user.Role.idRole;
                MessageBox.Show($"Добро пожаловать! Ваша роль: {user.Role.title}");
            } 
            else
                MessageBox.Show("Неверно введены логин или пароль!");
        }
    }
}