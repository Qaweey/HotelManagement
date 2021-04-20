using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManagementAPI.DataModel
{
    public class HotelDBContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Roomtype> Roomtypes{ get; set; }
        public HotelDBContext(DbContextOptions<HotelDBContext>options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
