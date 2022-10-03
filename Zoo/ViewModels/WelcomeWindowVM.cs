
using Microsoft.Data.SqlClient;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zoo.Commands;
using Zoo.Models;
using Zoo.Views;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Zoo.ViewModels
{
    public class WelcomeWindowVM : BaseVM
    {
        #region Private Fields       
        private DelegateCommand selectAnimalsCommand;
        private DelegateCommand selectEventsCommand;
        private DelegateCommand selectTicketsCommand;
        private BaseVM selectedViewModel;
        #endregion

        #region Constructor
        public WelcomeWindowVM()
        {           
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        #endregion

        #region Properties
        public BaseVM SelectedViewModel
        {
            get { return selectedViewModel; }
            set 
            { 
                selectedViewModel = value; 
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }
        #endregion

        #region  Commands

        public ICommand UpdateViewCommand { get; set; } 
        public DelegateCommand SelectAnimalsCommand
        {
            get
            {
                return selectAnimalsCommand ?? (selectAnimalsCommand = new DelegateCommand(() =>
                {
                    //selectedViewModel = new AnimalsWindowVM();
                    /*AnimalsWindowVM x = new AnimalsWindowVM();
                    AnimalsWindow window = new AnimalsWindow();
                    window.DataContext = x;*/
                    //Window window = new AnimalsWindow();
                    //window.Show();
                    //System.Windows.Application.Current.Windows[0].Close();
                }));
            }
        }
       
                           
#endregion

    }
}

    

    

      


       
