using Core.Entities;
using Infrastructure.Interfaces;
using Infrastructure.Stores;
using Infrastructure.ViewModels;

namespace Infrastructure.Commands.ManageDrawers.EditDrawersCommands
{
    public class EditDrawerCommand : CommandBase
    {
        private readonly INavigationService _editDrawerViewModelNavigationService;
        private readonly DrawerStore _editDrawerStore;

        public EditDrawerCommand(INavigationService editDrawerViewModelNavigationService ,DrawerStore editDrawerStore)
        {
            _editDrawerViewModelNavigationService = editDrawerViewModelNavigationService;
            _editDrawerStore = editDrawerStore;
        }

        public override void Execute(object? drawer)
        {
            _editDrawerStore.SetSelectedDrawer(drawer as Drawer);
            _editDrawerViewModelNavigationService.Navigate();
        }
    }
}