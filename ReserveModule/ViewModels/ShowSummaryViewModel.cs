using CoreModule.Events;
using CoreModule.Models;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using ReserveModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimePeriod;

namespace ReserveModule.ViewModels
{
    public class ShowSummaryViewModel :BindableBase,INavigationAware
    {
        IRepository repository;
        IRegionManager manager;
        private DelegateCommand reserveRoom;
        public DelegateCommand ReserveRoom =>
           reserveRoom ?? (reserveRoom = new DelegateCommand(ExecuteReserveRoom, CanExecuteReserveRoom));


        private AddReservationModel Model;
        public AddReservationModel model
        {
            get { return Model; }
            set { SetProperty(ref Model, value);  }
        }
        
        

        void ExecuteReserveRoom()
        {
            if (model != null)
            {
                repository.AddReservation(model.UserID, model.room, model.From, model.To, model.activities, model.meals);
                //dialog
                //
                //
                //}
                ReserveRoom.RaiseCanExecuteChanged();
                agr.GetEvent<ResetReservationEvent>().Publish(true);
            }
           
        }

        bool CanExecuteReserveRoom()
        {            
            if(model.room!=null)
            {
                 bool check=repository.CheckReservationForRoom(model.room.RoomID, model.From, model.To);
                
                return !check;
            }
            else
            {
                return false;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            model = navigationContext.Parameters.GetValue<AddReservationModel>("AddReservation");
            ReserveRoom.RaiseCanExecuteChanged();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //return true;
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        IEventAggregator agr;
        public ShowSummaryViewModel(IRepository repo,IRegionManager mana ,IEventAggregator agr)
        {
            this.agr = agr;
            repository = repo;
            manager = mana;
            model = new AddReservationModel();






        }


    }
}
