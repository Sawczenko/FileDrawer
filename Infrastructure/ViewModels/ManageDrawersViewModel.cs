using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Commands;
using Infrastructure.Commands.ManageDrawers;
using Infrastructure.Commands.ManageDrawers.EditDrawersCommands;
using Infrastructure.Commands.Navigation;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
{
    public class ManageDrawersViewModel : ViewModelBase
    {
        private readonly DrawerStore _drawerStore;
        public ICommand AddNewDrawerCommand { get; }
        public ICommand EditDrawerCommand { get; }
        public ICommand LoadDrawersCommand { get; }

        private ObservableCollection<Drawer> _drawers;
        public ObservableCollection<Drawer> Drawers
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

        public ManageDrawersViewModel( DrawerStore drawerStore, INavigationService addNewDrawerModalNavigationService, INavigationService editDrawerModalNavigationService)
        {
            _drawerStore = drawerStore;
            AddNewDrawerCommand = new ModalNavigateCommand(addNewDrawerModalNavigationService);
            EditDrawerCommand = new EditDrawerCommand(editDrawerModalNavigationService, drawerStore);
            LoadDrawersCommand = new LoadDrawersCommand(this, drawerStore);
            LoadDrawersCommand.Execute(default);
            _drawerStore.DrawerAdded += OnDrawerAdded;
        }

        public override void Dispose()
        {
            _drawerStore.DrawerAdded -= OnDrawerAdded;
            base.Dispose();
        }

        private void OnDrawerAdded(Drawer drawer)
        {
            _drawers.Add(drawer);
        }

        public void LoadDrawers(IEnumerable<Drawer> drawers)
        {
            Drawers = new ObservableCollection<Drawer>(drawers);
        }
    }
}