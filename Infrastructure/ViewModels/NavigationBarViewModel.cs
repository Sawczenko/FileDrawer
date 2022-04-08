using System.Windows.Input;
using Infrastructure.Commands.NavigateCommands;
using Infrastructure.Interfaces;
using Infrastructure.Services;

namespace Infrastructure.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateCreateDrawerCommand { get; }

        public NavigationBarViewModel(INavigationService createDrawerNavigationService,
            INavigationService homeNavigationService)
        {
            NavigateCreateDrawerCommand = new NavigateCommand<ManageDrawersViewModel>(createDrawerNavigationService);
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}