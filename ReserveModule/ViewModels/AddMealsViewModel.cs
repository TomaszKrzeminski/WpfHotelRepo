using CoreModule.Events;
using CoreModule.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace ReserveModule.ViewModels
{
    public class AddMealsViewModel:BindableBase
    {
        private string header;
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }

        private DelegateCommand reset;
        public DelegateCommand Reset =>
            reset ?? (reset = new DelegateCommand(ExecuteReset, CanExecuteReset).ObservesProperty(()=>Count));

        void ExecuteReset()
        {
            BreakfastListChosen.Clear();
            DinnerListChosen.Clear();
            SupperListChosen.Clear();
            Calculate();
        }

        bool CanExecuteReset()
        {
            if (Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int Days { get; set; }
        public int Meals { get; set; }       

        private int count;
        public int Count
        {
            get { return count; }
            set { SetProperty(ref count, value); }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        private void Calculate()
        {
            Price = 0;
            Count = 0;
            Price += BreakfastListChosen.Sum(x => x.Price);
            Price += DinnerListChosen.Sum(x => x.Price);
            Price += SupperListChosen.Sum(x => x.Price);

            Count += BreakfastListChosen.Count();
            Count += DinnerListChosen.Count();
            Count += SupperListChosen.Count();

        }
        public ObservableCollection<Meal> BreakfastList { get; set; }
        public ObservableCollection<Meal> DinnerList { get; set; }
        public ObservableCollection<Meal> SupperList { get; set; }
        public ObservableCollection<Meal> BreakfastListChosen { get; set; }
        public ObservableCollection<Meal> DinnerListChosen { get; set; }
        public ObservableCollection<Meal> SupperListChosen { get; set; }

        private Meal selectedBreakfastList;
        public Meal SelectedBreakfastList
        {
            get { return selectedBreakfastList; }
            set { SetProperty(ref selectedBreakfastList, value); }
        }

        private Meal selectedDinnerList;
        public Meal SelectedDinnerList
        {
            get { return selectedDinnerList; }
            set { SetProperty(ref selectedDinnerList, value); }
        }

        private Meal selectedSupperList;
        public Meal SelectedSupperList
        {
            get { return selectedSupperList; }
            set { SetProperty(ref selectedSupperList, value); }
        }

        private Meal selectedBreakfastListChosen;
        public Meal SelectedBreakfastListChosen
        {
            get { return selectedBreakfastListChosen; }
            set { SetProperty(ref selectedBreakfastListChosen, value); }
        }

        private Meal selectedDinnerListChosen;
        public Meal SelectedDinnerListChosen
        {
            get { return selectedDinnerListChosen; }
            set { SetProperty(ref selectedDinnerListChosen, value); }
        }

        private Meal selectedSupperListChosen;
        public Meal SelectedSupperListChosen
        {
            get { return selectedSupperListChosen; }
            set { SetProperty(ref selectedSupperListChosen, value); }
        }
        private void AddToList(Meal selectedMeal,ObservableCollection<Meal> listA,ObservableCollection<Meal> listB)
        {
            Meal meal = listA.Where(x => x == selectedMeal).FirstOrDefault();
            listB.Add(meal);
            selectedMeal = listB.FirstOrDefault();
            Reset.RaiseCanExecuteChanged();
            Calculate();
        }
        private void RemoveFromList(Meal selectedMeal,ObservableCollection<Meal> listB)
        {
            Meal meal = listB.Where(x => x == selectedMeal).FirstOrDefault();
            listB.Remove(meal);
            selectedMeal = listB.FirstOrDefault();
            Reset.RaiseCanExecuteChanged();
            Calculate();
        }

        private DelegateCommand addBreakFast;
        public DelegateCommand AddBreakFast =>
            addBreakFast ?? (addBreakFast = new DelegateCommand(ExecuteAddBreakFast, CanExecuteAddBreakFast).ObservesProperty(() => CountMax).ObservesProperty(()=>BreakfastListChosen));


        public bool CheckCount(ObservableCollection<Meal> list)
        {
            int count = CountMax / 3;
            if (count > list.Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        void ExecuteAddBreakFast()
        {
            AddToList(SelectedBreakfastList, BreakfastList, BreakfastListChosen);
        }
        bool CanExecuteAddBreakFast()
        {

          return  CheckCount(BreakfastListChosen);
            
        }
        private DelegateCommand addDinner;
        public DelegateCommand AddDinner =>
            addDinner ?? (addDinner = new DelegateCommand(ExecuteAddDinner, CanExecuteAddDinner).ObservesProperty(()=>CountMax).ObservesProperty(()=>DinnerListChosen));
        void ExecuteAddDinner()
        {
            AddToList(SelectedDinnerList, DinnerList, DinnerListChosen);
        }
        bool CanExecuteAddDinner()
        {
           return CheckCount(DinnerListChosen);

        }
        private DelegateCommand addSupper;
        public DelegateCommand AddSupper =>
            addSupper ?? (addSupper = new DelegateCommand(ExecuteAddSupper, CanExecuteAddSupper).ObservesProperty(() => CountMax).ObservesProperty(()=>SupperListChosen));
        void ExecuteAddSupper()
        {
            AddToList(SelectedSupperList, SupperList, SupperListChosen);
        }
        bool CanExecuteAddSupper()
        {
           return   CheckCount(SupperListChosen);

        }

        private DelegateCommand removeBreakfast;
        public DelegateCommand RemoveBreakfast =>
            removeBreakfast ?? (removeBreakfast = new DelegateCommand(ExecuteRemoveBreakfast, CanExecuteRemoveBreakfast));
        void ExecuteRemoveBreakfast()
        {
            RemoveFromList(SelectedBreakfastListChosen, BreakfastListChosen);
        }
        bool CanExecuteRemoveBreakfast()
        {
            return true;
        }

        private DelegateCommand removeDinner;
        public DelegateCommand RemoveDinner =>
            removeDinner ?? (removeDinner = new DelegateCommand(ExecuteRemoveDinner, CanExecuteRemoveDinner));
        void ExecuteRemoveDinner()
        {
            RemoveFromList(SelectedDinnerListChosen, DinnerListChosen);
        }
        bool CanExecuteRemoveDinner()
        {
            return true;
        }

        private DelegateCommand removeSupper;
        public DelegateCommand RemoveSupper =>
            removeSupper ?? (removeSupper = new DelegateCommand(ExecuteRemoveSupper, CanExecuteRemoveSupper));
        void ExecuteRemoveSupper()
        {
            RemoveFromList(SelectedSupperListChosen, SupperListChosen);
        }
        bool CanExecuteRemoveSupper()
        {
            return true;
        }
        IRepository repo;
        private IEventAggregator agr;

        private DelegateCommand send;
        public DelegateCommand Send =>
            send ?? (send = new DelegateCommand(ExecuteSend, CanExecuteSend).ObservesProperty(()=>Count));

        void ExecuteSend()
        {
            List<Meal> meals = new List<Meal>();
            meals.AddRange(BreakfastListChosen);
            meals.AddRange(DinnerListChosen);
            meals.AddRange(SupperListChosen);
            agr.GetEvent<MealSendEvent>().Publish(meals);
        }

        bool CanExecuteSend()
        {
            if(Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public AddMealsViewModel(IRepository repo,IEventAggregator agr)
        {
            this.agr = agr;
           

            this.repo = repo;
            Header = "Posiłki";
            BreakfastList =new ObservableCollection<Meal>( repo.GetMealByDetails(MealType.Breakfast,null));
            DinnerList = new ObservableCollection<Meal>(repo.GetMealByDetails(MealType.Dinner, null));
            SupperList = new ObservableCollection<Meal>(repo.GetMealByDetails(MealType.Supper, null));
            //Take radom or fist meals x day

            BreakfastListChosen = new ObservableCollection<Meal>();
            DinnerListChosen =   new ObservableCollection<Meal>();
            SupperListChosen =   new ObservableCollection<Meal>();
            agr.GetEvent<MealCountEvent>().Subscribe(GetCount);
            CountMax = 3;
            Calculate();
        }

        private int countMax;
        public int CountMax
        {
            get { return countMax; }
            set { SetProperty(ref countMax, value); }
        }
        private void GetCount(int obj)
        {
            Reset.Execute();
            CountMax = obj*3;
        }
    }
}
