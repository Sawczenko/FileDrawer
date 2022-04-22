using System.Windows.Input;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Commands.Drawers.CreateNewDrawerCommands;
using Infrastructure.Interfaces;

namespace Infrastructure.ViewModels
{
    public class CreateNewDrawerViewModel : ViewModelBase
    {
        public ICommand SaveDrawerCommand { get; }
        public ICommand CloseCreatorCommand { get; }
        
        private readonly IDrawerRepository _drawerRepository;

        private Drawer _drawer;
        private string _drawerNameText;
        private string _drawerPathText;

        public string DrawerNameText
        {
            get => _drawerNameText;
            set
            {
                _drawerNameText = value;
                _drawer.Name = _drawerNameText;
                OnPropertyChanged(nameof(DrawerNameText));
            }
        }

        public string DrawerPathText
        {
            get => _drawerPathText;
            set
            {
                _drawerPathText = value;
                _drawer.DrawerPath = _drawerPathText;
                OnPropertyChanged(nameof(DrawerPathText));
            }
        }

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