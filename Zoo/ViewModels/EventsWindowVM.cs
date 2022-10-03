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
        #region Private Properties
        private List<Event> events;
        private List<Event> eventsByType;
        private List<Event> types;
        private Event selectedType;
        private Event selectedEvent;        
        private EventDbContext eventDbContext = new EventDbContext();
        private DelegateCommand selectAnimalsCommand;        
        private DelegateCommand selectTicketsCommand;
        private DelegateCommand searchEventsByTypeCommand;
        private bool isTextBoxVisible;
        #endregion

        #region Constructor
        public EventsWindowVM()
        {         
        FillTypes();
        isTextBoxVisible = false;
       
       
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
        public List<Event> EventsByType
        {
            get { return eventsByType; }
            set
            {
                eventsByType = value;
                OnPropertyChanged("EventsByType");
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
        public Event SelectedEvent
        {
            get { return selectedEvent; }
            set
            {
                selectedEvent = value;
                ChangeTextBoxVisibality();
                OnPropertyChanged("SelectedEvent");
            }
        }
        #endregion

        #region Commands
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

        public DelegateCommand SelectAnimalsCommand
        {
            get
            {
                return selectAnimalsCommand ?? (selectAnimalsCommand = new DelegateCommand(() =>
                {
                    
                    //Window window = new AnimalsWindow();
                    //window.Show();
                    //System.Windows.Application.Current.Windows[0].Close();
                }));
            }
        }
         
        #endregion

        #region Methods

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

        private void ChangeTextBoxVisibality()
        {
            if (SelectedEvent != null)
            {
                IsTextBoxVisible = true;
            }
        }

        #endregion

    }

}







