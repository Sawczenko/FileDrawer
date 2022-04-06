using System;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;
using Infrastructure.ViewModels;

namespace Infrastructure.Commands.NavigateCommands
{
    public class NavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly INavigationService<TViewModel> _navigationService;

        public NavigateCommand(INavigationService<TViewModel> navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.Navigate();
        }
    }
}