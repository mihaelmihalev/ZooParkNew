
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
        //private User user;
        private List<Animal> animals;
        private DelegateCommand selectAnimalsCommand;
        private DelegateCommand searchAnimalsByCategoryCommand;
        private List<Category> categories;
        private Category selectedCategory;
        public WelcomeWindowVM()
        {
            animals = new List<Animal>();
            categories = new List<Category>();
            //fillAnimals();
            fillCategories();            
        }
        public Category SelectedCategory
        {
            get { return selectedCategory; }
            set 
            {
                selectedCategory = value;
                OnPropertyChanged("SelectedCategory");
            }
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
        public DelegateCommand SearchAnimalsByCategoryCommand
        {
            get
            {
                return searchAnimalsByCategoryCommand ?? (searchAnimalsByCategoryCommand = new DelegateCommand(() =>
                {
                    if (SelectedCategory != null)
                    {
                       
                                               
                    }
                    else
                    {
                        fillAnimals();
                    }                                                      
                }));
            }
        }


        public List<Animal> Animals
        {
            get
            {
                return animals;
            }
            set
            {
                animals = value;
                OnPropertyChanged("Animals");
            }
        }

        public List<Category> Categories
        {
            get
            {
                return categories;
            }
            set
            {
                categories = value;
                OnPropertyChanged("Categories");
            }
        }
        private void fillAnimals()
        {
            AnimalDbContext context = new AnimalDbContext();
            Animals = context.Animals.ToList();         
        }

        private void fillCategories()
        {
            CategoryDbContext context = new CategoryDbContext();
            Categories = context.Categories.ToList();                       
        }



    }
}




