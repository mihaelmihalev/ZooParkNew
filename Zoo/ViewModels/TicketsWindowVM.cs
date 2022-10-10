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
using System.Windows.Input;
using Zoo.Commands;
using Prism.Commands;

namespace Zoo.ViewModels
{
    public class TicketsWindowVM : BaseVM
    {

        #region Private Fields
        private int familyCount;
        private int schoolCount;
        private int classicCount;
        private int finalPrice;
        private List<Ticket> tickets;
        private TicketDbContext ticketDbContext = new TicketDbContext();
        private ICommand addFamilyTicket;
        private ICommand removeFamilyTicket;
        private ICommand addSchoolTicket;
        private ICommand removeSchoolTicket;
        private ICommand addClassicTicket;
        private ICommand removeClassicTicket;
        #endregion

        #region Constructor
        public TicketsWindowVM()
        {
            tickets = new List<Ticket>();
            FillTickets();
            BuyTicketCommand = new BuyTicketCommand();





        }
        #endregion

        #region Properties


        public int FamilyCount
        {
            get
            {
                return familyCount;

            }
            set
            {

                familyCount = value;
                CalculateTicketsPrice();
                OnPropertyChanged("FamilyCount");

            }
        }
        public int SchoolCount
        {
            get { return schoolCount; }
            set
            {
                schoolCount = value;
                CalculateTicketsPrice();
                OnPropertyChanged("SchoolCount");
            }
        }
        public int ClassicCount
        {
            get { return classicCount; }
            set
            {
                classicCount = value;
                CalculateTicketsPrice();
                OnPropertyChanged("ClassicCount");
            }
        }
        public int FinalPrice
        {
            get { return finalPrice; }
            set
            {
                finalPrice = value;
                OnPropertyChanged("FinalPrice");
            }
        }
        public List<Ticket> Tickets
        {
            get { return tickets; }
            set
            {
                tickets = value;
                OnPropertyChanged("Tickets");


            }
        }
        #endregion

        #region Methods
        private void FillTickets()
        {
            Tickets = ticketDbContext.Tickets.ToList();
        }
        private void CalculateTicketsPrice()
        {
            FinalPrice = FamilyCount * 7 + SchoolCount * 5 + ClassicCount * 10;

        }


        #endregion

        #region Commands

        public ICommand BuyTicketCommand { get; set; }
        public ICommand AddFamilyTicket
        {
            get
            {
                return addFamilyTicket ?? (addFamilyTicket = new DelegateCommand(() =>
                {
                    FamilyCount++;



                }));
            }

        }

        public ICommand RemoveFamilyTicket
        {
            get
            {
                return removeFamilyTicket ?? (removeFamilyTicket = new DelegateCommand(() =>
                {
                    FamilyCount--;



                }));
            }

        }
        public ICommand AddSchoolTicket
        {
            get
            {
                return addSchoolTicket ?? (addSchoolTicket = new DelegateCommand(() =>
                {
                    SchoolCount++;



                }));
            }

        }

        public ICommand RemoveSchoolTicket
        {
            get
            {
                return removeSchoolTicket ?? (removeSchoolTicket = new DelegateCommand(() =>
                {
                    SchoolCount--;



                }));
            }

        }

        public ICommand AddClassicTicket
        {
            get
            {
                return addClassicTicket ?? (addClassicTicket = new DelegateCommand(() =>
                {
                    ClassicCount++;



                }));
            }

        }

        public ICommand RemoveClassicTicket
        {
            get
            {
                return removeClassicTicket ?? (removeClassicTicket = new DelegateCommand(() =>
                {
                    ClassicCount--;



                }));
            }

        }
    
    }
}

                
            
        #endregion
    




