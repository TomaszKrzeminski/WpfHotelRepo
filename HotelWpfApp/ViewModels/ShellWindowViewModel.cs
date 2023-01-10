using CoreModule.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWpfApp.ViewModels
{
    public class ShellWindowViewModel :BindableBase
    {

        HotelContext ctx;
        public ShellWindowViewModel(HotelContext ctx)
        {
            this.ctx = ctx;
            SeedData s = new SeedData(ctx);
            s.Seed();
        }

    }
}
