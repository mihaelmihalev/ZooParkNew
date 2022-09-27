
//using MongoDB.Driver.Core.Configuration;
using Microsoft.Data.SqlClient;
using Prism.Commands;
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
        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new DelegateCommand(() =>
                {
                    if (String.IsNullOrEmpty(this.username))
                    {
                        MessageBox.Show("Моля, въведете име!");
                    }
                    else if (String.IsNullOrEmpty(this.password))
                    {
                        MessageBox.Show("Моля, въведете парола!");
                    }
                    else
                    {
                        
                        user = userDbContext.Users.FirstOrDefault(u => u.username == this.Username && u.password == this.Password);

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
                }));

            }
        }
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
