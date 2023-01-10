using CoreModule.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReserveModule.ViewModels
{
    public class ReserveRoomViewModel:BindableBase
    {
        IRepository repository;
        private string header;
        public string Header
        {
            get { return header; }
            set { SetProperty(ref header, value); }
        }

       public ObservableCollection<Room> RoomList { get; set; }
        public ReserveRoomViewModel(IRepository repository,HotelContext ctx)
        {
            this.repository = repository;         
            Header = "Rezerwuj pokój";          

            RoomList = new ObservableCollection<Room>(repository.GetAllRooms());
        }
    }
}
