using System.Windows.Input;
using Core.Application.Commands.ManageDrawers.CreateNewDrawerCommands;
using Core.Application.Interfaces;
using Core.Application.Stores;
using Core.Entities.Entities;

namespace Core.Application.ViewModels
{
    public class CreateNewDrawerViewModel : ViewModelBase
    {
        private readonly DrawerStore _drawerStore;
        public ICommand SaveDrawerCommand { get; }
        public ICommand CloseCreatorCommand { get; }
        public Drawer Drawer { get; set; }

        public CreateNewDrawerViewModel(DrawerStore drawerStore,
        INavigationService closeModalNavigationService)
        {
            _drawerStore = drawerStore;
            Drawer = new Drawer();
            SaveDrawerCommand = new SaveDrawerCommand(drawerStore,closeModalNavigationService);
            CloseCreatorCommand = new CloseCreatorCommand(closeModalNavigationService);
        }

    }
}