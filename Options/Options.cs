using OptionsModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionsModule
{
    public class Options : IModule
    {
        IRegionManager manager;
        public void OnInitialized(IContainerProvider containerProvider)
        {
            manager.RegisterViewWithRegion("ContentOptions", typeof(ViewOptions));
        }

        public Options(IRegionManager manager)
        {
            this.manager = manager;
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<ViewOptions>();
            //ViewModelLocationProvider.Register<ViewE, ViewEViewModel>();
        }
    }
}
