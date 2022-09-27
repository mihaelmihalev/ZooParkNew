
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
    public class AnimalsWindowVM : BaseVM
    {
        #region Private fields
        private List<Animal> animals;
        private List<Animal> animalsByCategory;
        private List<Animal> categories;
        private Animal selectedAnimal;
        private Animal selectedCategory;
        private CategoryDbContext categoryDbContext = new CategoryDbContext();
        private AnimalDbContext animalDbContext = new AnimalDbContext();
        private DelegateCommand selectAnimalsCommand;
        private DelegateCommand selectEventsCommand;
        private DelegateCommand selectTicketsCommand;
        private DelegateCommand searchAnimalsByCategoryCommand;
        private bool isTextBoxVisible;
        #endregion

        #region Constructor

        public AnimalsWindowVM()
        {
            isTextBoxVisible = false;
            FillCategories();

        }
        #endregion

        #region Properties
        public bool IsTextBoxVisible
        {
            get { return isTextBoxVisible; }
            set 
            { 
                
                isTextBoxVisible = value;
                OnPropertyChanged("IsTextBoxVisible");
            }
        }
        public Animal SelectedAnimal
        {
            get
            {
                return selectedAnimal;
            }
            set
            {
                selectedAnimal = value;
                ChangeTextBoxVisibality();
                OnPropertyChanged("SelectedAnimal");
            }
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
            get
            {
                return categoryDbContext;
            }
            set
            {
                categoryDbContext = value;
                OnPropertyChanged("CategoryDbContext");
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
        #endregion

        #region Commands
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

                    Window window = new TicketsWindow();
                    window.Show();
                    System.Windows.Application.Current.Windows[0].Close();
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
        #endregion

        #region Methods

        private void FillAnimals()
        {
            Animals = animalDbContext.Animals.ToList();

        }

        private void FillCategories()
        {
            Categories = animalDbContext.Animals.GroupBy(animal => animal.Category).Select(a =>a.First()).ToList();
        }


        private void GetAnimalByCategory()
        {
            Animals = (from a in animalDbContext.Animals where a.Category.Equals(SelectedCategory.Category) select a).Distinct().ToList(); //.Distinct();
        }

        private void ChangeTextBoxVisibality()
        {
            if(SelectedAnimal != null)
            {
                IsTextBoxVisible = true;
            }
           /* else
            {
                IsTextBoxVisible = false;
            }*/
        }
        #endregion

    }


}