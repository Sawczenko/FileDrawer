using System.Linq;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Interfaces;

namespace Infrastructure.Commands.Drawers.CreateNewDrawerCommands
{
    public class SaveDrawerCommand : CommandBase
    {
        private readonly IDrawerRepository _drawerRepository;
        private readonly INavigationService _closeModalNavigationService;

        public SaveDrawerCommand(IDrawerRepository drawerRepository ,INavigationService closeModalNavigationService)
        {
            _drawerRepository = drawerRepository;
            _closeModalNavigationService = closeModalNavigationService;
        }
        //TODO Validation
        public override void Execute(object? parameter)
        {
            Drawer drawer = parameter as Drawer;
            _drawerRepository.AddDrawer(drawer);
            _closeModalNavigationService.Navigate();
        }
    }
}