using Core.Application.Interfaces;

namespace Core.Application.Commands.ManageDrawers.CreateNewDrawerCommands
{
    public class CloseCreatorCommand : CommandBase
    {
        private readonly INavigationService _closeModalNavigationService;

        public CloseCreatorCommand(INavigationService closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
        }
        public override void Execute(object? parameter)
        {
            _closeModalNavigationService.Navigate();
        }
    }
}