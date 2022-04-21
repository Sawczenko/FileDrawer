using Infrastructure.Interfaces;

namespace Infrastructure.Commands.Drawers.CreateNewDrawerCommands
{
    public class SaveDrawerCommand : CommandBase
    {
        private readonly INavigationService _closeModalNavigationService;

        public SaveDrawerCommand(INavigationService closeModalNavigationService)
        {
            _closeModalNavigationService = closeModalNavigationService;
        }
        public override void Execute(object? parameter)
        {
            _closeModalNavigationService.Navigate();
        }
    }
}