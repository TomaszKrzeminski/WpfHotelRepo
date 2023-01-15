using CoreModule.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TimePeriod;

namespace CoreModule.Models
{
    public interface IRepository
    {
        List<Room> GetAllRooms();
        List<Meal> GetAllMeals();
        List<Activity> GetAllActivities();
        List<Meal> GetMealByDetails(MealType? type, DayOfWeekForMeals days);
        List<User> GetAllUsers();
        User AddUser(AddUserModel user);
        bool AddReservation(int UserID, Room room, DateTime startDate, DateTime endDate, List<Activity> activities, List<Meal> meals);

        bool CheckReservationForRoom(int RoomID,DateTime start,DateTime end);

        List<Room> GetAvailableRooms(DateTime start, DateTime end);
    }

    public class Repository : IRepository
    {
        HotelContext ctx;
        public Repository(HotelContext ctx)
        {
            this.ctx = ctx;
        }

        public bool AddReservation(int UserID, Room room, DateTime startDate, DateTime endDate, List<Activity> activities, List<Meal> meals)
        {
            try
            {
                Reservation reservation = new Reservation(startDate, endDate);
                ctx.Reservations.Add(reservation);
                ctx.SaveChanges();               

                if(activities!= null&&activities.Count()>0)
                {

                    foreach (var item in activities)
                    {
                        ReservationActivity a = new ReservationActivity() { Reservation = reservation, Activity = item };
                        reservation.reservationActivities.Add(a);
                        ctx.SaveChanges();
                    }

                }

                if (meals != null && meals.Count() > 0)
                {
                    foreach (var item in meals)
                    {
                        ReservationMeal a = new ReservationMeal() { Reservation = reservation, Meal = item };
                        reservation.reservationMeals.Add(a);
                        ctx.SaveChanges();
                    }
                }


                User userAdd = ctx.Users.Include(x=>x.reservations).Where(x=>x.UserID==UserID).FirstOrDefault();
                userAdd.reservations.Add(reservation);
                ctx.SaveChanges();

                Room roomAdd = ctx.Rooms.Include(x=>x.reservations).Where(x => x.RoomID == room.RoomID).FirstOrDefault(); ;
                roomAdd.reservations.Add(reservation);
                ctx.SaveChanges();



                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public User AddUser(AddUserModel user)
        {
            try
            {
                User add = new User(user);
                ctx.Users.Add(add);
                return add;
            }
            catch(Exception ex)
            {
                return new User();
            }
        }
        //public bool CheckReservationForRoom(int RoomID,DateTime start,DateTime end)
        //{
        //    try
        //    {
        //        bool check = ctx.Rooms.Include(x => x.reservations).Where(x => x.RoomID == RoomID).SelectMany(x => x.reservations).Any(x => x.StartDate <= start && x.StartDate <= end || x.EndDate >= start && x.EndDate <= end);



        //        return check;
        //    }
        //    catch(Exception ex)
        //    {
        //        return true;
        //    }
        //}

        public bool CheckReservationForRoom(int RoomID, DateTime start, DateTime end)
        {
            try
            {
               List<Reservation> list = ctx.Rooms.Include(x => x.reservations).Where(x => x.RoomID == RoomID).SelectMany(x => x.reservations).Where(x => x.EndDate > start ).ToList();
                TimeRange period = new TimeRange(start,end);

                foreach (var item in list)
                {                   
                    bool check= period.OverlapsWith(new TimeRange(item.StartDate, item.EndDate));                 
                    if(check)
                    {
                        return true;
                    }
                }


                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
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
        public List<User> GetAllUsers()
        {
            try
            {
                return ctx.Users.ToList();
            }
            catch(Exception ex) 
            {

                return new List<User>();
            
            }
        }

        public List<Room> GetAvailableRooms(DateTime start, DateTime end)
        {
            List<Room> rooms=new List<Room>();
            try
            {
                List<Room> roomslist = ctx.Rooms.Include(x => x.reservations).ToList();
                List<Room> except = new List<Room>();

                foreach (var r in roomslist)
                {
                    bool check = CheckReservationForRoom(r.RoomID, start, end);
                    if(check)
                    {
                        except.Add(r);
                    }
                }
                

               if(except.Count > 0) 
                {
                    rooms = ctx.Rooms.AsEnumerable().Except(except).ToList();
                }
               else
                {
                    rooms = ctx.Rooms.ToList();
                }
                return rooms;
               
            }
            catch(Exception ex)
            {
                return rooms;
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
