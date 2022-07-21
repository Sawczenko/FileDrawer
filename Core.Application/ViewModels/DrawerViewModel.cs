using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Entities;

namespace Core.Application.ViewModels
{
    public class DrawerViewModel : ViewModelBase
    {

        public DrawerViewModel(Drawer drawer)
        {
            Drawer = drawer;
        }

        public Drawer Drawer { get; set; }
    }
}
