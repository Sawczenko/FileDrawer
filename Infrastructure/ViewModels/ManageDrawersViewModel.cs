using System.Windows.Input;
using Infrastructure.Commands;
using Infrastructure.Commands.DrawerCommands;
using Infrastructure.Commands.NavigateCommands;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
{
    public class ManageDrawersViewModel : ViewModelBase
    {
        public ICommand AddNewDrawerCommand { get; }
        public ICommand OpenModal { get; }
        private INavigationService _modalNavigationService;

        public ManageDrawersViewModel()
        {
            //_modalNavigationService = modalNavigationService;
            AddNewDrawerCommand = new AddNewDrawerCommand();
            OpenModal = new ModalNavigateCommand<HomeViewModel>(_modalNavigationService);
        }
    }
}