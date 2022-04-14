using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.ViewModels;

namespace Infrastructure.Commands.NavigateCommands
{
    public class ModalNavigateCommand<TViewModel> : CommandBase where TViewModel : ViewModelBase
    {
        private readonly INavigationService _modalNavigationService;

        public ModalNavigateCommand(INavigationService modalNavigationService)
        {
            _modalNavigationService = modalNavigationService;
        }

        public override void Execute(object? parameter)
        {
            _modalNavigationService.Navigate();
        }
    }
}