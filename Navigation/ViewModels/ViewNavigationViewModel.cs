using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationModule.ViewModels
{
    public class ViewNavigationViewModel : BindableBase, INavigationAware
    {
        IRegionNavigationJournal journal;

        private DelegateCommand foward;
        public DelegateCommand Foward =>
            foward ?? (foward = new DelegateCommand(ExecuteFoward, CanExecuteFoward));

        void ExecuteFoward()
        {
            ar mainregion = _regionManager.Regions[RegionNames.mainregion];
            mainregion.NavigationService.Journal.GoForward();
        }

        bool CanExecuteFoward()
        {
            return true;
        }

        private DelegateCommand back;
        public DelegateCommand Back =>
            back ?? (back = new DelegateCommand(ExecuteBack, CanExecuteBack));

        void ExecuteBack()
        {
            var mainregion = manager.Regions[RegionNames.mainregion];
            mainregion.NavigationService.Journal.GoBack();
        }

        bool CanExecuteBack()
        {
            return true;
        }


        IRegionManager manager { get; set; }
        public ViewNavigationViewModel(IRegionManager manager)
        {
            this.manager = manager;
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
