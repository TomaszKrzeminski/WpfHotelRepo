using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace OptionsModule.ViewModels
{
    public class ViewOptionsViewModel:BindableBase
    {
        IRegionManager manager;
        public DelegateCommand<string> NavigateCommand { get; set; }
       


        public ViewOptionsViewModel(IRegionManager manager)
        {
            this.manager = manager;
            NavigateCommand = new DelegateCommand<string>(Navigate, CanNavigate);
           
        }

        private bool CanNavigate(string arg)
        {
            return true;
        }
       
        private void Navigate(string uri)
        {
            manager.RequestNavigate("ContentReserveMain", uri);
        }
    }
}
