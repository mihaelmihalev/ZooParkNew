
using Microsoft.Data.SqlClient;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.IO;
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
    public class AnimalsWindowVM : BaseVM
    {
        #region Private fields
        private List<Animal> animals;
        private List<Animal> animalsByCategory;
        private List<Animal> categories;
        private Animal selectedAnimal;
        private Animal selectedCategory;
        //private CategoryDbContext categoryDbContext = new CategoryDbContext();
        private AnimalDbContext animalDbContext = new AnimalDbContext();
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
            // FillAnimalData();

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
            Animals = (from a in animalDbContext.Animals where a.Category.Equals(SelectedCategory.Category) select a).ToList(); //.Distinct();
        }

        private void ChangeTextBoxVisibality()
        {
            if(SelectedAnimal != null)
            {
                IsTextBoxVisible = true;
            }
        }
       /* public void FillAnimalData()
        {            
                Animal animal1 = new Animal(1, "Лъв", "Хищници" , "Лъвът (Panthera leo) е едър хищник от семейство Коткови и един от четирите представители на род Пантери."
                    , File.ReadAllBytes("C:/Users/mihael.mihalev/Desktop/Izpitvane/Zoo/Zoo/Images/lion.jpg"));
                Animal animal2 = new Animal(2, "Маймуна","Бозайници", "Маймуните (Haplorrhini) са таксономичен подразред, който заедно с подразред Полумаймуни (Strepsirrhini) образуват разред Примати (Primates)."
                    , File.ReadAllBytes("C:/Users/mihael.mihalev/Desktop/Izpitvane/Zoo/Zoo/Images/monkey.jpg"));
                Animal animal3 = new Animal(3,"Змия","Влечуги", "Змиите са удължени, студенокръвни безкраки влечуги от подразред Serpentes, близки родственици на гущерите, с които спадат към един и същи разред – Люспести."
                    , File.ReadAllBytes("C:/Users/mihael.mihalev/Desktop/Izpitvane/Zoo/Zoo/Images/snake.jpg"));
                animalDbContext.Animals.Add(animal1);
                animalDbContext.Animals.Add(animal2);
                animalDbContext.Animals.Add(animal3);
                animalDbContext.SaveChanges();
                
            }*/
        }
        #endregion

}


