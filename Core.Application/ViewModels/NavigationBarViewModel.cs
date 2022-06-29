using System.Windows.Input;
using Core.Application.Commands.Navigation;
using Core.Application.Interfaces;

namespace Core.Application.ViewModels
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