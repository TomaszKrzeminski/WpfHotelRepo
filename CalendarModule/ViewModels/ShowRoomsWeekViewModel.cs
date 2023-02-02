using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarModule.ViewModels
{
    class ShowRoomsWeekViewModel:BindableBase
    {
        private string test;
        public string Test
        {
            get { return test; }
            set { SetProperty(ref test, value); }
        }
        public ShowRoomsWeekViewModel()
        {
            Test = "Test widoku";
        }


    }
}
