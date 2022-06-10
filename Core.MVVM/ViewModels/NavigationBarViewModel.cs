using System.Windows.Input;
using Infrastructure.Commands.Navigation;
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
            NavigateCreateDrawerCommand = new NavigateCommand(createDrawerNavigationService);
            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }
    }
}