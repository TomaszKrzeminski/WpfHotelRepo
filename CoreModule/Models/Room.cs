using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Identity.Client;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.Models
{


    public class ReservationActivity
    {
        public ReservationActivity()
        {

        }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }

        public int ActivityID { get; set; }
        public Activity Activity { get; set; }
    }

    public class ReservationMeal
    {
        public ReservationMeal()
        {

        }
        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }

        public int MealID { get; set; }
        public Meal Meal { get; set; }
    }

    public class Reservation
    {
        public Reservation()
        {

        }
        public Reservation( DateTime startDate, DateTime endDate, int? userID, User user)
        {            
            StartDate = startDate;
            EndDate = endDate;
            UserID = userID;
            User = user;
            reservationMeals = new List<ReservationMeal>();
            reservationActivities = new List<ReservationActivity>();

        }

        public int ReservationID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? UserID { get; set; }
        public virtual User User { get; set; }

        public int? RoomID { get; set; }
        public virtual Room Room { get; set; }

        public virtual List<ReservationActivity> reservationActivities { get; set; }
        public virtual List<ReservationMeal> reservationMeals { get; set; }
    }


    public class User
    {
        public User( string firstName, string city, string street, string houseNumber, string postalCode, string personalNumber)
        {
           
            FirstName = firstName;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
            PostalCode = postalCode;
            PersonalNumber = personalNumber;
            reservations = new List<Reservation>();
        }

        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string PostalCode { get; set; }
        public string PersonalNumber { get; set; }

        public virtual List<Reservation> reservations { get; set; }
    }
    public enum RoomType
    {
        Single_Room, Double_Room, Triple_Room, Four_Person_Room
    }
    public class Room
    {
        public Room( int beeds, bool bathroom, bool tV, int appartments, RoomType roomType,decimal price)
        {
           
            Beeds = beeds;
            Bathroom = bathroom;
            TV = tV;
            Appartments = appartments;
            RoomType = roomType;
            Price = price;
        }
        public Room()
        {
            Beeds = 1;
            Bathroom = false;
            TV = false;
            Appartments = 1;
            RoomType = RoomType.Single_Room;
            reservations = new List<Reservation>();
        }

        public int RoomID { get; set; }
        public int Beeds { get; set; }
        public bool Bathroom { get; set; }
        public bool TV { get; set; }
        public int Appartments { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }

        List<Reservation> reservations { get; set; }


    }
    public enum MealType
    {
        Breakfast, Dinner, Supper
    }

    public class Meal
    {
        public Meal(MealType type, string name, decimal price)
        {
            this.type = type;
            Name = name;
            Price = price;
            daysOfWeek = new List<DayOfWeekForMeals>();
            reservationMeals = new List<ReservationMeal>();
        }

        public int MealID { get; set; }
        public MealType type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual List<DayOfWeekForMeals> daysOfWeek { get; set; }
        public virtual List<ReservationMeal> reservationMeals { get; set; }
    }

    public class DayOfWeekForMeals
    {
        public DayOfWeekForMeals(DayOfWeek dayofWeek)
        {
            this.dayofWeek = dayofWeek;
        }

        public DayOfWeekForMeals()
        {

        }

        public int DayOfWeekForMealsID { get; set; }
        public DayOfWeek dayofWeek { get; set; }

        public int? MealID { get; set; }
        public virtual Meal Meal { get; set; }
    }

    public class Activity
    {
        public Activity(string name, decimal price, string description)
        {

            Name = name;
            Price = price;
            Description = description;
        }
        public Activity()
        {
            reservationActivities = new List<ReservationActivity>();
        }

        public int ActivityID { get; set; }       
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public virtual List<ReservationActivity> reservationActivities { get; set; }
    }
}
