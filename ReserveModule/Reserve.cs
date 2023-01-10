using Microsoft.EntityFrameworkCore;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using ReserveModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreModule.Models;
using DryIoc;
using System.ComponentModel;

namespace ReserveModule
{
    public class Reserve : IModule
    {

        IRegionManager manager;
        HotelContext ctx;
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //Register region with view
            manager.RegisterViewWithRegion("ContentReservation", typeof(ReserveRoom));
            manager.RegisterViewWithRegion("ContentReservation", typeof(AddMeals));
            manager.RegisterViewWithRegion("ContentReservation", typeof(AddActivities));
        }

        public Reserve(IRegionManager manager)
        {
            this.manager = manager;
          
           
        }

        
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {



            //var optionsBuilder = new DbContextOptionsBuilder<HotelContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=HotelWpfApp;Trusted_Connection=True;");
            //containerRegistry.RegisterInstance(optionsBuilder.Options);
            containerRegistry.RegisterSingleton<HotelContext>();
            containerRegistry.Register<IRepository, Repository>();
            containerRegistry.RegisterForNavigation<ReservationViews>();

            
        }
      
    }
}
