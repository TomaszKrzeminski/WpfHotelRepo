using CoreModule.Converters;
using CoreModule.Events;
using CoreModule.Models;
using CoreModule.ViewModels;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveModule.ViewModels
{
    public class ReserveRoomViewModel : BindableBase,INavigationAware
    {
        IRepository repository;
        private string header;
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }
        private bool tv;
        public bool TV
        {
            get { return tv; }
            set { SetProperty(ref tv, value); FilteringRooms.Execute(); }
        }

        private bool bathroom;
        public bool Bathroom
        {
            get { return bathroom; }
            set { SetProperty(ref bathroom, value); FilteringRooms.Execute(); }
        }

        private DateTime reservationFrom;
        public DateTime ReservationFrom
        {
            get { return reservationFrom; }
            set { SetProperty(ref reservationFrom, value); FilteringRooms.Execute(); Calculate(); }
        } 

        private DateTime reservationTo;
        public DateTime ReservationTo
        {
            get { return reservationTo; }
            set { SetProperty(ref reservationTo, value); FilteringRooms.Execute(); Calculate(); }
        }
        private Room roomToAdd;
        public Room RoomToAdd
        {
            get { return roomToAdd; }
            set { SetProperty(ref roomToAdd, value); }
        }

        private RadioOptions selectedRoom;
        public RadioOptions SelectedRoom
        {
            get { return selectedRoom; }
            set { SetProperty(ref selectedRoom, value); FilteringRooms.Execute(); }
        }
        public RadioOptions selectedPeople;
        public RadioOptions SelectedPeople
        {
            get { return selectedPeople; }
            set { SetProperty(ref selectedPeople, value); FilteringRooms.Execute(); }
        }

        private RadioOptions selectedBeeds;
        public RadioOptions SelectedBeeds
        {
            get { return selectedBeeds; }
            set { SetProperty(ref selectedBeeds, value); FilteringRooms.Execute(); }
        }
        private DelegateCommand addUser;
        public DelegateCommand AddUser =>
            addUser ?? (addUser = new DelegateCommand(ExecuteAddUser, CanExecuteAddUser));
        void ExecuteAddUser()
        {
            if (!String.IsNullOrEmpty(SelectedUser.PersonalNumber))
            {
                if (!repository.GetAllUsers().Any(x => x.PersonalNumber == SelectedUser.PersonalNumber))
                {
                    User user = repository.AddUser(SelectedUser);
                    UsersList.Add(new AddUserModel(user));
                }
            }

        }
        bool CanExecuteAddUser()
        {
            return true;
        }
        private DelegateCommand resetUser;
        public DelegateCommand ResetUser =>
            resetUser ?? (resetUser = new DelegateCommand(ExecuteResetUser, CanExecuteResetUser));
        void ExecuteResetUser()
        {
            SelectedUser = new AddUserModel();
        }
        bool CanExecuteResetUser()
        {
            return true;
        }
        public ObservableCollection<Room> RoomList { get; set; }
        public ObservableCollection<AddUserModel> UsersList { get; set; }
        private AddUserModel selectedUser;
        public AddUserModel SelectedUser
        {
            get { return selectedUser; }
            set { SetProperty(ref selectedUser, value); }
        }
        private DelegateCommand reserveRoom;
        public DelegateCommand ReserveRoom =>
            reserveRoom ?? (reserveRoom = new DelegateCommand(ExecuteReserveRoom, CanExecuteReserveRoom));

        //void ExecuteReserveRoom()
        //{

        //    repository.AddReservation(SelectedUser.UserID, RoomToAdd, ReservationFrom,ReservationTo,activities,meals);
        //    filteringRooms.Execute();
        //}

        void ExecuteReserveRoom()
        {
            meals  ??= new List<Meal>();
            meals = GetRandomMeals(meals); 
            AddReservationModel model = new AddReservationModel(SelectedUser.UserID, RoomToAdd, ReservationFrom, ReservationTo, activities, meals);
            model.UserName = SelectedUser.FirstName;
            model.UserSurname= SelectedUser.LastName;
            model.PersonalNumber= SelectedUser.PersonalNumber;          
            NavigationParameters par = new NavigationParameters();
            par.Add("AddReservation", model);
            manager.RequestNavigate("ContentReserveMain", "ShowSummary", par);
            
        }

        private List<Meal> GetRandomMeals(List<Meal> meals)
        {

            int count = Calculate();
            int breakfast = 0;
            int dinner = 0;
            int supper = 0;

            foreach (var item in meals)
            {
                if(item.type==MealType.Breakfast)
                {
                    breakfast++;
                }
                else if(item.type==MealType.Dinner) 
                {
                    dinner++;
                }
                else
                {
                    supper++;
                }
            }


            if(breakfast<count)
            {
                int x = count - breakfast;
                for (int i = 0; i < x; i++)
                {
                    meals.Add(repository.GetRandomMeal(false,MealType.Breakfast));
                }
            }

            if(dinner<count)
            {
                int x = count - dinner;
                for (int i = 0; i < x; i++)
                {
                    meals.Add(repository.GetRandomMeal(false, MealType.Dinner));
                }
            }

            if(supper<count)
            {
                int x = count - supper;
                for (int i = 0; i < x; i++)
                {
                    meals.Add(repository.GetRandomMeal(false, MealType.Supper));
                }
            }
            return meals;

        }
        bool CanExecuteReserveRoom()
        {
            return true;
        }
        private DelegateCommand filteringRooms;
        public DelegateCommand FilteringRooms =>
            filteringRooms ?? (filteringRooms = new DelegateCommand(ExecuteFilteringRooms, CanExecuteFilteringRooms));

        void ExecuteFilteringRooms()
        {
            int beds = (int)SelectedBeeds+1;
            int rooms = (int)SelectedRoom + 1;
            RoomType people = (RoomType)SelectedPeople; ;           

            List<Room> checkList =new List<Room>(repository.GetAllRooms());
            List<Room> list2 =new List<Room>( checkList.Where(x => x.TV == TV && x.Bathroom == Bathroom && x.Beeds == beds && x.Appartments == rooms && x.RoomType == people).ToList());
           

            List<Room> listRemove = new List<Room>();

            for (int i = 0; i < list2.Count(); i++)            
            {
                bool check = repository.CheckReservationForRoom(list2[i].RoomID, ReservationFrom, ReservationTo);
                if (check)
                {
                    listRemove.Add(list2[i]);
                }          


            }

            for (int i = 0; i < listRemove.Count(); i++)
            {
                list2.Remove(listRemove[i]);
            }

            RoomList.Clear();
            RoomList.AddRange(list2);
            

        }
        List<Meal> meals { get; set; }
        List<Activity> activities { get; set; }        
        int Calculate()
        {
            int DaysCount = 0;
            if (ReservationTo != null && reservationFrom != null&&ReservationFrom<ReservationTo)
            {
                DaysCount = (ReservationTo.Date - reservationFrom.Date).Days;
            }
            
            agr.GetEvent<MealCountEvent>().Publish(DaysCount);
            return DaysCount;
        }
        bool CanExecuteFilteringRooms()
        {
            return true;
        }
        private IEventAggregator agr;

        private DelegateCommand showAll;
        public DelegateCommand ShowAll =>
            showAll ?? (showAll = new DelegateCommand(ExecuteShowAll, CanExecuteShowAll));

        void ExecuteShowAll()
        {
            List<Room> list=repository.GetAvailableRooms(ReservationFrom, ReservationTo);
            RoomList.Clear();
            RoomList.AddRange(list);
        }

        bool CanExecuteShowAll()
        {
            return true;
        }
        IRegionManager manager;
        public ReserveRoomViewModel(IRepository repository, HotelContext ctx,IEventAggregator agr,IRegionManager manager)
        {
            this.manager = manager;
            this.agr = agr;
            agr.GetEvent<MealSendEvent>().Subscribe(GetMeals);
            agr.GetEvent<ActivitySendEvent>().Subscribe(GetEvents);
            agr.GetEvent<ResetReservationEvent>().Subscribe(ResetView);
           
            this.repository = repository;
            Header = "Rezerwuj pokój";

            RoomList = new ObservableCollection<Room>(repository.GetAllRooms());
            UsersList = new ObservableCollection<AddUserModel>(repository.GetAllUsers().Select(x => new AddUserModel(x)).ToList());
            SelectedUser = UsersList.LastOrDefault();
            SelectedPeople = RadioOptions.Option1;
            SelectedRoom = RadioOptions.Option1;
            ReservationFrom = DateTime.Now;
            ReservationTo = DateTime.Now.AddDays(1);
            Calculate();
            
        }

        private void ResetView(bool obj)
        {
            if(obj==true)
            {
                ReservationFrom = DateTime.Now;
                ReservationTo = DateTime.Now.AddDays(1);
            }
        }

        private void GetEvents(List<Activity> list)
        {
            activities = list;
        }

        private void GetMeals(List<Meal> list)
        {
            meals = list;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            FilteringRooms.Execute();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            FilteringRooms.Execute();
        }
    }
}
