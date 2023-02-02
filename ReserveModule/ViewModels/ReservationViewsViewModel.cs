using CoreModule.Models;
using Prism.Mvvm;
using Prism.Regions;
using ReserveModule.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ReserveModule.ViewModels
{
    public class ReservationViewsViewModel : BindableBase, IConfirmNavigationRequest
    {
        
        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            var result = true;

            if (MessageBox.Show("Czy chcesz przerwać rezerwację", "Przerwij", MessageBoxButton.YesNo) == MessageBoxResult.No)
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
