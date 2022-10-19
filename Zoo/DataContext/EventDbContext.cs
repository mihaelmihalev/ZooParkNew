using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Models;

namespace Zoo
{
    public class EventDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to mysql with connection string from app settings
            options.UseSqlServer(@"Data Source=.\SQLEXPRESS00;Initial Catalog=ZooPark;Integrated Security=True");
        }
        public DbSet<Event> Events { get; set; }
    }
}

