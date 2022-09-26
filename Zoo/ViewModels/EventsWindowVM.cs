using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sql;
using Zoo.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Zoo.Views;
using System.Windows;

namespace Zoo.ViewModels
{
    public class EventsWindowVM : BaseVM
    {
            private List<Event> events;
            private List<Event> eventsByType;
            private List<Event> types;
            private Event selectedType;
            private CategoryDbContext categoryDbContext = new CategoryDbContext();
            private AnimalDbContext animalDbContext = new AnimalDbContext();
            private EventDbContext eventDbContext = new EventDbContext();


            private DelegateCommand selectAnimalsCommand;
            private DelegateCommand selectEventsCommand;
            private DelegateCommand selectTicketsCommand;
            private DelegateCommand searchEventsByTypeCommand;
            public EventsWindowVM()
            {
                events = new List<Event>();
                types = new List<Event>();
                //fillAnimals();
                FillTypes();
            }


            public List<Event> EventsByType
            {
                get { return eventsByType; }
                set
                {
                    eventsByType = value;
                    OnPropertyChanged("EventsByType");
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

            public Event SelectedType
            {
                get { return selectedType; }
                set
                {
                    selectedType = value;
                    OnPropertyChanged("SelectedType");
                }
            }

            public DelegateCommand SearchEventsByTypeCommand
            {
                get
                {
                    return searchEventsByTypeCommand ?? (searchEventsByTypeCommand = new DelegateCommand(() =>
                    {
                        if (SelectedType != null)
                        {
                            GetEventByType();


                        }
                        else
                        {

                            FillEvents();
                        }
                    }));
                }
            }


            public List<Event> Events
            {
                get
                {
                    return events;
                }
                set
                {
                    events = value;
                    OnPropertyChanged("Events");
                }
            }

            public List<Event> Types
            {
                get
                {
                    return types;
                }
                set
                {
                    types = value;
                    OnPropertyChanged("Types");
                }
            }
            private void FillEvents()
            {
            Events = eventDbContext.Events.ToList();
            }

            private void FillTypes()
            {
            Types = eventDbContext.Events.ToList();


            }


            private void GetEventByType()
            {

                Events = (from a in eventDbContext.Events where a.Type.Equals(SelectedType.Type) select a).Distinct().ToList(); //.Distinct();
            




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

                    //Window window = new EventsWindow();
                    // window.Show();
                    //System.Windows.Application.Current.Windows[0].Close();
                }));
            }
        }
    }

}







