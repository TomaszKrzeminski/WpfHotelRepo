using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalendarModule.ViewModels
{
    class MainCalendarViewModel:BindableBase,IConfirmNavigationRequest
    {

        public MainCalendarViewModel()
        {

        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = true;

            if (MessageBox.Show("Czy chcesz opuścić kalendarz", "Opuść", MessageBoxButton.YesNo) == MessageBoxResult.No)
            {
              result = false;
            }
                

            continuationCallback(result);

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
