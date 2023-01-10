using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreModule.Models
{
    public class SeedData
    {
        HotelContext ctx;
        public SeedData(HotelContext context)
        { 
            this.ctx = context;
        }
        public void AddActivity(Activity activity)
        {
            ctx.Activities.Add(activity);
            ctx.SaveChanges();
        }
        public void AddMeal(Meal meal,List<DayOfWeekForMeals> mealDayList)
        {
            meal.daysOfWeek.AddRange(mealDayList);
            ctx.Meals.Add(meal);
            ctx.SaveChanges();
        }
        public void AddRoom(Room room)
        {
            ctx.Rooms.Add(room);
            ctx.SaveChanges();
        }

        public DayOfWeekForMeals AddDayofWeekForMeal(DayOfWeekForMeals mealDay)
        {
            ctx.DayOfWeekForMeals.Add(mealDay);
            ctx.SaveChanges();
            return mealDay;
        }



        public void Seed()
        {
           bool check= ctx.Database.EnsureCreated();

            if(check&&ctx.Rooms!=null&&ctx.Rooms.Count()==0)
            {
                AddActivity( new Activity("Siłownia", 15, "1 wejście na siłownię"));
                 AddActivity( new Activity("Wypożycznie roweru", 10, "Wypożycznie roweru na 1 dzień"));
                AddActivity( new Activity("Wejście na basen", 20, "1 godzina na basenie"));
              AddActivity( new Activity("Wejście do sauny", 20, "1 godzina na saunie"));
                AddActivity( new Activity("Masaż", 100, "1 godzina masażu"));


                DayOfWeekForMeals Monday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Monday));
                DayOfWeekForMeals Tuesday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Tuesday));
                DayOfWeekForMeals Wednesday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Wednesday));
                DayOfWeekForMeals Thursday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Thursday));
                DayOfWeekForMeals Friday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Friday));
                DayOfWeekForMeals Saturday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Saturday));
                DayOfWeekForMeals Sunday = AddDayofWeekForMeal(new DayOfWeekForMeals(DayOfWeek.Sunday));


                AddMeal(new Meal(MealType.Breakfast,"Płatki kukurydziane z mlekiem",0),new List<DayOfWeekForMeals>() {Monday, Tuesday, Wednesday, Thursday, Friday,Saturday,Sunday});
                AddMeal(new Meal(MealType.Breakfast, "Naleśniki z nutellą", 0), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday });
                AddMeal(new Meal(MealType.Breakfast, "Jajecznica z boczkiem", 10), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday});
                AddMeal(new Meal(MealType.Breakfast, "Gotowana i wędzona szynka, salami, kiełbasy ,chleb", 10), new List<DayOfWeekForMeals>() {  Friday, Saturday, Sunday });

                AddMeal(new Meal(MealType.Dinner, "Filet drobiowy w migdałową panierką otulony w towarzystwie pieczonych ziemniaczków i pysznej surówki z marchewki z pomarańczą.", 0), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday });
                AddMeal(new Meal(MealType.Dinner, "Pizza ", 10), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday });
                AddMeal(new Meal(MealType.Dinner, "Mintaj złocistą panierką otulony z ziemniakami z wody i surówką z kapusty kiszonej z marchewką podany.", 10), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday });
                AddMeal(new Meal(MealType.Dinner, "Filet z indyczej piersi zapiekany ananasem i serem podawany z frytkami i lekką surówką szefa kuchni.", 20), new List<DayOfWeekForMeals>() {  Friday, Saturday, Sunday });

                AddMeal(new Meal(MealType.Supper, "Polędwiczki drobiowe w sosie z włoszczyzną", 0), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday });
                AddMeal(new Meal(MealType.Supper, "Schab duszony z marchewką", 5), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday });
                AddMeal(new Meal(MealType.Supper, "Tortille mieszane", 10), new List<DayOfWeekForMeals>() { Monday, Tuesday, Wednesday, Thursday, Friday });
                AddMeal(new Meal(MealType.Supper, "Tatar z łososia", 20), new List<DayOfWeekForMeals>() { Friday, Saturday, Sunday });


                AddRoom(new Room(1, false, false, 1, RoomType.Single_Room,100));
                AddRoom(new Room(1, true, false, 2, RoomType.Single_Room,120));
                AddRoom(new Room(1, false, true, 1, RoomType.Single_Room,140));
                AddRoom(new Room(1, true, true, 2, RoomType.Single_Room,160));
                AddRoom(new Room(1, false, false, 1, RoomType.Double_Room,200));

                AddRoom(new Room(2, false, false, 1, RoomType.Double_Room, 200));
                AddRoom(new Room(2, true, false, 2, RoomType.Double_Room, 220));
                AddRoom(new Room(2, false, true, 1, RoomType.Double_Room, 240));
                AddRoom(new Room(2, true, true, 2, RoomType.Double_Room, 260));
                AddRoom(new Room(3, false, false, 2, RoomType.Triple_Room, 300));

                AddRoom(new Room(1, false, false, 1, RoomType.Triple_Room, 300));
                AddRoom(new Room(2, true, false, 2, RoomType.Triple_Room, 320));
                AddRoom(new Room(1, false, true, 1, RoomType.Triple_Room, 340));
                AddRoom(new Room(2, true, true, 2, RoomType.Triple_Room, 360));
                AddRoom(new Room(1, false, false, 1, RoomType.Four_Person_Room, 300));

                AddRoom(new Room(1, false, false, 1, RoomType.Four_Person_Room, 400));
                AddRoom(new Room(2, true, false, 2, RoomType.Four_Person_Room, 420));
                AddRoom(new Room(1, false, true, 1, RoomType.Four_Person_Room, 440));
                AddRoom(new Room(2, true, true, 2, RoomType.Four_Person_Room, 460));
                AddRoom(new Room(2, false, false, 2, RoomType.Four_Person_Room, 500));



            }

        }


        }


    
}
