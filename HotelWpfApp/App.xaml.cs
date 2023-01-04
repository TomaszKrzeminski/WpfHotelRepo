using HotelWpfApp.Views;
using NavigationModule;
using OptionsModule;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;


namespace HotelWpfApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<ShellWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            
        }

        //Add Modules
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {

            moduleCatalog.AddModule<Options>();
            moduleCatalog.AddModule<Navigation>();

        }
    }
}
