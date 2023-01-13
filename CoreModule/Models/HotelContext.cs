using CoreModule.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;


namespace CoreModule.Models
{


    public class HotelContext : DbContext
    {

        public HotelContext()
        {

        }

        public HotelContext(DbContextOptions options) : base(options) 
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ReservationActivity>().HasKey(sc => new { sc.ReservationID, sc.ActivityID });
            modelBuilder.Entity<ReservationMeal>().HasKey(sc => new { sc.ReservationID, sc.MealID });

            //modelBuilder.Entity<BookAuthor>().HasKey(sc => new { sc.BookID, sc.AuthorID });
        }

        protected override void OnConfiguring(
             DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotelWpfApp;Trusted_Connection=True;");
        }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Activity> Activities { get; set; }         
        public DbSet<DayOfWeekForMeals> DayOfWeekForMeals { get;set; }
        public DbSet<ReservationActivity> ReservationActivities { get; set; }
        public DbSet<ReservationMeal> ReservationMeals { get; set;}
        public DbSet<User> Users { get; set; }
        public DbSet<Reservation> Reservations { get; set; }


    }

}
