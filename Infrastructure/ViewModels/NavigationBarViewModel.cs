using System.Windows.Input;
using Infrastructure.Commands.NavigateCommands;
using Infrastructure.Services;

namespace Infrastructure.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateCreateDrawerCommand { get; }

        public NavigationBarViewModel(NavigationService<CreateDrawerViewModel> createDrawerNavigationService,
            NavigationService<HomeViewModel> homeNavigationService)
        {
            NavigateCreateDrawerCommand = new NavigateCommand<CreateDrawerViewModel>(createDrawerNavigationService);
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}