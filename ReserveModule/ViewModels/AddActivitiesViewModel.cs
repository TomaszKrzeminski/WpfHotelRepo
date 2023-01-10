using CoreModule.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveModule.ViewModels
{
    public class AddActivitiesViewModel : BindableBase
    {
        private string header;
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }

        private int listCount;
        public int ListCount
        {
            get { return listCount; }
            set { SetProperty(ref listCount, value); }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }

        private Activity selected;
        public Activity Selected
        {
            get { return selected; }
            set { SetProperty(ref selected, value); }
        }

        private Activity selectedA;
        public Activity SelectedA
        {
            get { return selectedA; }
            set { SetProperty(ref selectedA, value); }
        }
        private DelegateCommand addActivity;
        public DelegateCommand AddActivity { get { return addActivity; } set { addActivity = value; } }

        void ExecuteAddActivity()
        {
            Activity activity = ActivitiesList.Where(x => x.ActivityID == Selected.ActivityID).FirstOrDefault();
            AddedActivitiesList.Add(activity);
            SelectedA = addedActivitiesList.FirstOrDefault();
            Reset.RaiseCanExecuteChanged();
            Calculate();

        }

        bool CanExecuteAddActivity()
        {

            return true;
        }

        private DelegateCommand removeActivity;
        public DelegateCommand RemoveActivity { get; set; }

        private DelegateCommand reset;
        public DelegateCommand Reset { get; set; }


        void ExecuteReset()
        {
            AddedActivitiesList.Clear();
            Calculate();
        }

        bool CanExecuteReset()
        {
            if (AddedActivitiesList.Count() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private bool CanExecuteRemoveActivity()
        {
            if(SelectedA!= null)
            {
              return true;
            }
            else
            {
                return false;
            }
        }

        private void ExecuteRemoveActivity()
        {
            Activity activity = AddedActivitiesList.Where(x => x == SelectedA).FirstOrDefault();
            AddedActivitiesList.Remove(activity);
            SelectedA = AddedActivitiesList.FirstOrDefault();
            Reset.RaiseCanExecuteChanged();
            Calculate();
        }

        public void Calculate()
        {
            ListCount = AddedActivitiesList.Count();
            Price = AddedActivitiesList.Sum(x => x.Price);
        }
        public ObservableCollection<Activity> ActivitiesList { get; set; }      

        private ObservableCollection<Activity> addedActivitiesList;
        public ObservableCollection<Activity> AddedActivitiesList
        {
            get { return addedActivitiesList; }
            set { SetProperty(ref addedActivitiesList, value);  }
        }

        IRepository repo;
        public AddActivitiesViewModel(IRepository repo)
        {
            Header = "Aktywności";
            this.repo = repo;
            AddActivity = new DelegateCommand(ExecuteAddActivity, CanExecuteAddActivity);
            RemoveActivity = new DelegateCommand(ExecuteRemoveActivity, CanExecuteRemoveActivity).ObservesProperty(()=>SelectedA);
            ActivitiesList = new ObservableCollection<Activity>(repo.GetAllActivities());
            AddedActivitiesList = new ObservableCollection<Activity>();
            Reset = new DelegateCommand(ExecuteReset, CanExecuteReset);
        }
    }
}


