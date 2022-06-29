using System.Threading.Tasks;
using Core.Application.Stores;
using Core.Application.ViewModels;

namespace Core.Application.Commands.ManageDrawers
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
            _manageDrawersViewModel.LoadDrawers(_drawerStore.GetDrawers());
        }
    }
}
