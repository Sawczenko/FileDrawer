using Core.Application.Interfaces;

namespace Core.Application.Commands.Navigation
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