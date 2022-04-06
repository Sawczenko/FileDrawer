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

        public NavigationBarViewModel(INavigationService<CreateDrawerViewModel> createDrawerNavigationService,
            INavigationService<HomeViewModel> homeNavigationService)
        {
            NavigateCreateDrawerCommand = new NavigateCommand<CreateDrawerViewModel>(createDrawerNavigationService);
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}