using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.Models
{
    public interface IRepository
    {
        List<Room> GetAllRooms();
        List<Meal> GetAllMeals();
        List<Activity> GetAllActivities();
        List<Meal> GetMealByDetails(MealType? type, DayOfWeekForMeals days);
    }

    public class Repository : IRepository
    {
        HotelContext ctx;
        public Repository(HotelContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Activity> GetAllActivities()
        {
            List<Activity> list = new List<Activity>();
            try
            {
                list=ctx.Activities.ToList();
                return list;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        public List<Meal> GetAllMeals()
        {
            List<Meal> list = new List<Meal>();
            try
            {
                list=ctx.Meals.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<Room> GetAllRooms()
        {
            List<Room> list = new List<Room>();
            try
            {
                list = ctx.Rooms.ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Meal> GetMealByDetails(MealType? type, DayOfWeekForMeals days)
        {
            List<Meal> list = new List<Meal>();
            try
            {
                if(type!=null)
                {
                    List<Meal> listType=ctx.Meals.Where(x=>x.type==type).ToList();
                    list.AddRange(listType);
                }
                if(days!=null)
                {
                    List<Meal> listType = ctx.Meals.Include(x => x.daysOfWeek).Where(x => x.daysOfWeek.Any(x => x.dayofWeek == days.dayofWeek)).ToList();
                    list.AddRange(listType);
                }

                var x = list.GroupBy(x => x.MealID).Select(x => x.First()).ToList();
                list = x;
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

       
    }
}
