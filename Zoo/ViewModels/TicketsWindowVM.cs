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
        private DelegateCommand addFamilyTicket;
        private DelegateCommand removeFamilyTicket;
        private DelegateCommand addSchoolTicket;
        private DelegateCommand removeSchoolTicket;
        private DelegateCommand addClassicTicket;
        private DelegateCommand removeClassicTicket;
        private DelegateCommand buyTicketCommand;

        #endregion

        #region Constructor
        public TicketsWindowVM()
        {
            tickets = new List<Ticket>();
            FillTickets();


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
        public DelegateCommand AddFamilyTicket
        {
            get
            {
                return addFamilyTicket ?? (addFamilyTicket = new DelegateCommand((o) =>
                {
                    FamilyCount++;
                }));
            }
        }
        public DelegateCommand RemoveFamilyTicket
        {
            get
            {
                return removeFamilyTicket ?? (removeFamilyTicket = new DelegateCommand((o) =>
                {
                    if (FamilyCount > 0)
                    {
                        FamilyCount--;
                    }
                }));
            }
        }
        public DelegateCommand AddSchoolTicket
        {
            get
            {
                return addSchoolTicket ?? (addSchoolTicket = new DelegateCommand((o) =>
                {
                    SchoolCount++;
                }));
            }
        }
        public DelegateCommand RemoveSchoolTicket
        {
            get
            {
                return removeSchoolTicket ?? (removeSchoolTicket = new DelegateCommand((o) =>
                {
                    if (SchoolCount > 0)
                    {
                        SchoolCount--;
                    }
                }));
            }
        }

        public DelegateCommand AddClassicTicket
        {
            get
            {
                return addClassicTicket ?? (addClassicTicket = new DelegateCommand((o) =>
                {
                    ClassicCount++;
                }));
            }
        }

        public DelegateCommand RemoveClassicTicket
        {
            get
            {
                return removeClassicTicket ?? (removeClassicTicket = new DelegateCommand((o) =>
                {
                    if (ClassicCount > 0)
                    {
                        ClassicCount--;
                    }
                }));
            }
        }

        public DelegateCommand BuyTicketCommand
        {
            get
            {
                return buyTicketCommand ?? (buyTicketCommand = new DelegateCommand((o) =>
                {
                    MessageBox.Show("Успешно закупихте билет/и");
                }));
            }
        }
    }
}

#endregion
    




