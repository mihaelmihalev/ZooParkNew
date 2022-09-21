
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
        //private User user;
        private List<Animal> animals;
        private List<Animal> animalsByCategory;
       
        private DelegateCommand selectAnimalsCommand;
        private DelegateCommand searchAnimalsByCategoryCommand;
        private List<Animal> categories;
        private Animal selectedCategory;
        private CategoryDbContext categoryDbContext = new CategoryDbContext();
        private AnimalDbContext animalDbContext = new AnimalDbContext();
        public WelcomeWindowVM()
        {
            animals = new List<Animal>();
            categories = new List<Animal>();
            //fillAnimals();
            FillCategories();            
        }


        public List<Animal> AnimalsByCategory
        {
            get { return animalsByCategory; }
            set 
            { 
                animalsByCategory = value;
                OnPropertyChanged("AnimalsByCategory");
            }
        }
        public CategoryDbContext CategoryDbContext
        {
            get { 
                return categoryDbContext;
                }
            set { 
                categoryDbContext = value; 
                OnPropertyChanged("CategoryDbContext");
                }
        }
        public AnimalDbContext AnimalDbContext
        {
            get
            {
                return animalDbContext;
            }
            set
            {
                animalDbContext = value;
                OnPropertyChanged("AnimalDbContext");
            }
        }

        public Animal SelectedCategory
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
                        GetAnimalByCategory();
                        
                                               
                    }
                    else
                    {
                        
                        FillAnimals();
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

        public List<Animal> Categories
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
        private void FillAnimals()
        {
            Animals = AnimalDbContext.Animals.ToList();       
        }

        private void FillCategories()
        {
           
            Categories = AnimalDbContext.Animals.ToList();                       
        }


        private void GetAnimalByCategory()
        {
            Animals = (from a in AnimalDbContext.Animals where a.Category.Equals(SelectedCategory.Category) select a).ToList(); //.Distinct();
            




        }
        /* private void DeleteCategoryIfExist()
         {
             int count = 0;
             foreach(Animal animal in Animals)
             {
                 if (animal.Category.Equals(SelectedCategory.Category))
                     {
                     count++;
                     }
                 if(count > 0)
             }
         }*/

    }
}




