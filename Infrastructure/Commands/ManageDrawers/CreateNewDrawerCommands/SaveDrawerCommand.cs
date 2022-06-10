using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Stores;
using Infrastructure.ViewModels;

namespace Infrastructure.Commands.ManageDrawers.CreateNewDrawerCommands
{
    public class SaveDrawerCommand : AsyncCommandBase
    { 
        private readonly DrawerStore _drawerStore;
        private readonly INavigationService _closeModalNavigationService;

        public SaveDrawerCommand(DrawerStore drawerStore, INavigationService closeModalNavigationService)
        {
            _drawerStore = drawerStore;
            _closeModalNavigationService = closeModalNavigationService;
        }
        //TODO Validation
        public override async Task ExecuteAsync(object? parameter)
        {
            Drawer drawer = parameter as Drawer;
            drawer.FileList = new List<DrawerFile>();
            await _drawerStore.AddDrawer(drawer);
            _closeModalNavigationService.Navigate();
        }
    }
}