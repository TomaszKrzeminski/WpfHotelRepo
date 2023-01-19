using CoreModule.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.Models
{

    public class AddReservationModel
    {
        public AddReservationModel()
        {

        }
        public AddReservationModel(int userID, Room room, DateTime from, DateTime to, List<Activity> activities, List<Meal> meals)
        {
            UserID = userID;
            this.room = room;
            From = from;
            To = to;
            this.activities = activities;
            this.meals = meals;
            Days = (To.Day - From.Day);
            MealsCost = SetMealCost();
            ActivitiesCost = SetActivityCost();
            FinalCost = SetFinalCost();

        }

        public int UserID { get; set; }

        public string UserName { get; set; }
        public string UserSurname { get; set; }

        public string PersonalNumber { get; set; }
        public Room room { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int Days { get; set; }
        public List<Activity>? activities { get; set; }
        public List<Meal>? meals { get; set; }

        public decimal MealsCost { get; set; }
        public decimal ActivitiesCost { get; set; }
        public decimal FinalCost { get; set; }

        //model.ActivitiesCost = activities.Sum(x => x.Price);
        //model.MealsCost = meals.Sum(x => x.Price);
        //model.FinalCost = model.ActivitiesCost + model.MealsCost + (RoomToAdd.Price * Calculate());

        public decimal SetMealCost()
        {
            if(meals!=null)
            {
                return meals.Sum(x => x.Price);
            }
            else
            {
                return 0;
            }
        }
        public decimal SetActivityCost()
        {
            if(activities!=null)
            {
              return  activities.Sum(x => x.Price);
            }
            else
            {
                return 0;
            }
        }

        public decimal SetFinalCost()
        {
            if (room != null)
            {
                return FinalCost = SetMealCost() + SetActivityCost() + room.Price * Days;
            }
            else
            {
                return 0;
            }

        }

    }
}
