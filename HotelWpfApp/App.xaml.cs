using CoreModule.Models;
using HotelWpfApp.Views;
using NavigationModule;
using OptionsModule;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using ReserveModule;
using System.Windows;


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
            containerRegistry.RegisterSingleton<HotelContext>();

        }

        //Add Modules
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<Options>();
            moduleCatalog.AddModule<Navigation>();
            moduleCatalog.AddModule<Reserve>();
            moduleCatalog.AddModule<CalendarModule.Calendar>();
        }
    }
}
