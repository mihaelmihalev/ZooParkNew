
using Microsoft.Data.SqlClient;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zoo.Models;
using Zoo.Views;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Zoo.ViewModels
{
    internal class WelcomeWindowVM : BaseVM
    {
        /*private User user;
        private List<Animal> animals;
        private List<Animal> animalsByCategory;     
        
        
        private DelegateCommand searchAnimalsByCategoryCommand;
        private List<Animal> categories;
        private Animal selectedCategory;*/
        private CategoryDbContext categoryDbContext = new CategoryDbContext();
        private AnimalDbContext animalDbContext = new AnimalDbContext();
        private DelegateCommand selectAnimalsCommand;
        private DelegateCommand selectEventsCommand;
        private DelegateCommand selectTicketsCommand;
        public WelcomeWindowVM()
        {
            /*animals = new List<Animal>();
            categories = new List<Animal>();
            //fillAnimals();
            FillCategories();    */
        }
                      
        public DelegateCommand SelectAnimalsCommand
        {
            get
            {
                return selectAnimalsCommand ?? (selectAnimalsCommand = new DelegateCommand(() =>
                {

                    Window window = new AnimalsWindow();
                    window.Show();
                    System.Windows.Application.Current.Windows[0].Close();
                }));
            }
        }
        public DelegateCommand SelectTicketsCommand
        {
            get
            {
                return selectTicketsCommand ?? (selectTicketsCommand = new DelegateCommand(() =>
                {

                    //Window window = new TicketsWindow();
                   // window.Show();
                   // System.Windows.Application.Current.Windows[0].Close();
                }));
            }
        }
        public DelegateCommand SelectEventsCommand
        {
            get
            {
                return selectEventsCommand ?? (selectEventsCommand = new DelegateCommand(() =>
                {

                    Window window = new EventsWindow();
                    window.Show();
                    System.Windows.Application.Current.Windows[0].Close();
                }));
            }
        }
    }
}

    

    

      


       
