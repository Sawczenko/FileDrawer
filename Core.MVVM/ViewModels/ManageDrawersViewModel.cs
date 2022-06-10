using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Commands;
using Infrastructure.Commands.ManageDrawers.EditDrawersCommands;
using Infrastructure.Commands.Navigation;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
{
    public class ManageDrawersViewModel : ViewModelBase
    {
        private readonly IDrawerRepository _drawerRepository;
        public ICommand AddNewDrawerCommand { get; }
        public ICommand EditDrawerCommand { get; }


        private List<Drawer> _drawers;
        public List<Drawer> Drawers
        {
            get => _drawers;
            set
            {
                _drawers = value;
                OnPropertyChanged(nameof(Drawers));
            }
        }

        private Drawer _drawer;
        public Drawer Drawer
        {
            get => _drawer;
            set
            {
                _drawer = value;
                OnPropertyChanged(nameof(Drawer));
            }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        public ManageDrawersViewModel(IDrawerRepository drawerRepository,INavigationService addNewDrawerModalNavigationService, INavigationService editDrawerModalNavigationService)
        {
            _drawerRepository = drawerRepository;
            AddNewDrawerCommand = new ModalNavigateCommand(addNewDrawerModalNavigationService);
            EditDrawerCommand = new ModalNavigateCommand(editDrawerModalNavigationService);
            LoadDrawers();
        }

        private void LoadDrawers()
        {
            Drawers = _drawerRepository.GetDrawers().ToList();
        }
    }
}