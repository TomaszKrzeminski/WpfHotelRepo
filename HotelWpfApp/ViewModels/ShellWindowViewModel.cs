using CoreModule.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace HotelWpfApp.ViewModels
{
    public class ShellWindowViewModel : BindableBase, INavigationAware
    {

        HotelContext ctx;
        IRegionNavigationJournal journal;

        




        public ShellWindowViewModel(HotelContext ctx)
        {
            this.ctx = ctx;
            SeedData s = new SeedData(ctx);
            s.Seed();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
          
        }
    }
}
