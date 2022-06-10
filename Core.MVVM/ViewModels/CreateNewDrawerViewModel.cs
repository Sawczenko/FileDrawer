using System.Windows.Input;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Commands.ManageDrawers.CreateNewDrawerCommands;
using Infrastructure.Interfaces;

namespace Infrastructure.ViewModels
{
    public class CreateNewDrawerViewModel : ViewModelBase
    {
        public ICommand SaveDrawerCommand { get; }
        public ICommand CloseCreatorCommand { get; }
        
        private readonly IDrawerRepository _drawerRepository;

        private Drawer _drawer;
        public Drawer Drawer
        {
            get => _drawer;
            set => _drawer = value;
        }

        public CreateNewDrawerViewModel(IDrawerRepository drawerRepository,
        INavigationService closeModalNavigationService)
        {
            _drawer = new Drawer();
            _drawerRepository = drawerRepository;
            SaveDrawerCommand = new SaveDrawerCommand(_drawerRepository,closeModalNavigationService);
            CloseCreatorCommand = new CloseCreatorCommand(closeModalNavigationService);
        }
        
    }
}