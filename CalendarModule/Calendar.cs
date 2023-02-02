using CalendarModule.Views;
using CoreModule.Models;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarModule
{
    public class Calendar : IModule
    {

        IRegionManager manager;
        HotelContext ctx;
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //Register region with view
            manager.RegisterViewWithRegion("ContentCalendar", typeof(ShowRoomsWeek));      


        }

        public Calendar(IRegionManager manager)
        {
            this.manager = manager;


        }


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {



           
            containerRegistry.RegisterInstance<HotelContext>(new HotelContext());
            containerRegistry.Register<IRepository, Repository>();
            containerRegistry.RegisterForNavigation<MainCalendar>();
            

        }

    }
}

