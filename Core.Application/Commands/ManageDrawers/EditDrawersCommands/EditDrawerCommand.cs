using Core.Application.Interfaces;
using Core.Application.Stores;
using Core.Entities.Entities;

namespace Core.Application.Commands.ManageDrawers.EditDrawersCommands
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