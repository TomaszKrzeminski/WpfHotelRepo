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
        Meal GetRandomMeal(bool paid);
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


                List<ReservationActivity> list1 = new List<ReservationActivity>();

                if(activities!= null&&activities.Count()>0)
                {

                    for ( int i=0;i<activities.Count;i++)
                    {
                        if (list1.Any(x => x.ActivityID == activities[i].ActivityID))
                        {
                            ReservationActivity x = list1.Where(x => x.ActivityID == activities[i].ActivityID).First();
                            int count = x.Count;
                            count++;
                            x.Count = count;
                        }
                        else
                        {
                            ReservationActivity a = new ReservationActivity() { Reservation = reservation, ReservationID = reservation.ReservationID, Activity = activities[i], ActivityID = activities[i].ActivityID, Count = 1 };
                            list1.Add(a);
                        }                        
                      
                    }

                }

                foreach (var item in list1)
                {
                    reservation.reservationActivities.Add(item);
                    ctx.SaveChanges();
                }

                List<ReservationMeal> list2 = new List<ReservationMeal>();

                if (meals != null && meals.Count > 0)
                {

                    for (int i = 0; i < meals.Count; i++)
                    {
                        if (list2.Any(x => x.MealID == meals[i].MealID))
                        {
                            ReservationMeal x = list2.Where(x => x.MealID == meals[i].MealID).First();
                            int count = x.Count;
                            count++;
                            x.Count = count;
                        }
                        else
                        {
                            ReservationMeal a = new ReservationMeal() { Reservation = reservation, ReservationID = reservation.ReservationID, Meal = meals[i], MealID = meals[i].MealID, Count = 1 };
                            list2.Add(a);
                        }
                    }                   
                       
                    
                }

                foreach (var item in list2)
                {
                    reservation.reservationMeals.Add(item);
                    ctx.SaveChanges();
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

        public Meal GetRandomMeal(bool paid)
        {
           
            List<Meal> meal=ctx.Meals.Where(x=>x.Price>0).



        }
    }
}
