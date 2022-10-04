
using Microsoft.Data.SqlClient;
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


namespace Zoo.ViewModels
{
    public class WelcomeWindowVM : BaseVM
    {
        #region Private Fields           
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
        
                                        
#endregion

    }
}

    

    

      


       
