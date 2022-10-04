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
        private List<Ticket> tickets;                    
        private TicketDbContext ticketDbContext = new TicketDbContext();
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
        
            
        #endregion

        #region Commands
        
        public ICommand BuyTicketCommand { get; set; }
                
            
        #endregion
    }

}


