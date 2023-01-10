using Microsoft.EntityFrameworkCore.Update.Internal;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.Models
{
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
        }

        public int RoomID { get; set; }
        public int Beeds { get; set; }
        public bool Bathroom { get; set; }
        public bool TV { get; set; }
        public int Appartments { get; set; }
        public RoomType RoomType { get; set; }
        public decimal Price { get; set; }



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
        }

        public int MealID { get; set; }
        public MealType type { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual List<DayOfWeekForMeals> daysOfWeek { get; set; }
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

    public class Activity:BindableBase
    {
        public Activity(string name, decimal price, string description)
        {

            Name = name;
            Price = price;
            Description = description;
        }
        public Activity()
        {

        }

        private int activityID;
        public int ActivityID
        {
            get { return activityID; }
            set { SetProperty(ref activityID, value); }
        }
        //public int ActivityID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
