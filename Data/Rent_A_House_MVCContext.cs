using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;

namespace Rent_A_House_MVC.Models
{
    //Connects and maps the model objects to databse tables.
    public class Rent_A_House_MVCContext : DbContext
    {
        public Rent_A_House_MVCContext (DbContextOptions<Rent_A_House_MVCContext> options)
            : base(options)
        {
        }

        public DbSet<Rent_A_House.BusinessLayer.Contract> Contract { get; set; }

        public DbSet<Rent_A_House.BusinessLayer.House> House { get; set; }

        public DbSet<Rent_A_House.BusinessLayer.HouseOwner> HouseOwner { get; set; }

        public DbSet<Rent_A_House.BusinessLayer.Tenant> Tenant { get; set; }
    }
}
