using NavigationModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationModule
{
    public class Navigation : IModule
    {
        IRegionManager manager;
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //Register region with view
            manager.RegisterViewWithRegion("ContentNavigation", typeof(ViewNavigation));
        }

        public Navigation(IRegionManager manager)
        {
            this.manager = manager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<ViewE>();
            //ViewModelLocationProvider.Register<ViewE, ViewEViewModel>();
        }
    }
}
