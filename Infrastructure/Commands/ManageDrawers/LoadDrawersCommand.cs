using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Stores;
using Infrastructure.ViewModels;

namespace Infrastructure.Commands.ManageDrawers
{
    class LoadDrawersCommand : AsyncCommandBase
    {
        private readonly ManageDrawersViewModel _manageDrawersViewModel;
        private readonly DrawerStore _drawerStore;

        public LoadDrawersCommand(ManageDrawersViewModel manageDrawersViewModel, DrawerStore drawerStore)
        {
            _manageDrawersViewModel = manageDrawersViewModel;
            _drawerStore = drawerStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _drawerStore.LoadDrawers();
            _manageDrawersViewModel.LoadDrawers(_drawerStore.Drawers);
        }
    }
}
