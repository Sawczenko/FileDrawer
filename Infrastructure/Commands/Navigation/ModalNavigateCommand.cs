using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.ViewModels;

namespace Infrastructure.Commands.Navigation
{
    public class ModalNavigateCommand : CommandBase
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