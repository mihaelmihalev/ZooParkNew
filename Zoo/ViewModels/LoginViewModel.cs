
//using MongoDB.Driver.Core.Configuration;
using Microsoft.Data.SqlClient;
using Zoo.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zoo;
using Zoo.Models;
using Zoo.ViewModels;

namespace Zoo
{
    public class LoginViewModel : BaseVM
    {
        #region Private Fields
        private String username;
        private String password;
        private User user;
        private DelegateCommand loginCommand;
        private UserDbContext userDbContext = new UserDbContext();
        #endregion

        #region Commands

        private void CheckUser(object a)
        {
            if (String.IsNullOrEmpty(username))
            {
                MessageBox.Show("Моля, въведете име!");
            }
            else if (String.IsNullOrEmpty(password))
            {
                MessageBox.Show("Моля, въведете парола!");
            }
            else
            {

                user = userDbContext.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

                if (user != null)
                {
                    Window window = new WelcomeWindow();
                    window.Show();
                    System.Windows.Application.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Грешни данни за вход!");
                }
            }
        }

        public ICommand LoginCommand=> loginCommand ?? (loginCommand = new DelegateCommand(CheckUser));

        #endregion

        #region Properties
        public String Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value.Trim();
                OnPropertyChanged("Username");
            }
        }

        public String Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        #endregion
    }
}
