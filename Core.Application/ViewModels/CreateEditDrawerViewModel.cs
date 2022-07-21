using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.Application.Commands.ManageDrawers.CreateNewDrawerCommands;
using Core.Application.Commands.ManageDrawers.EditDrawersCommands;
using Core.Application.Interfaces;
using Core.Application.Stores;
using Core.Entities.Entities;

namespace Core.Application.ViewModels
{
    public class CreateEditDrawerViewModel : ViewModelBase
    {
        private readonly DrawerStore _drawerStore;
        public ICommand SaveDrawerCommand { get; }
        public ICommand CloseCreatorCommand { get; }
        public ICommand AddFilesCommand { get; }

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

        private ObservableCollection<DrawerFile> _drawerFiles;

        public ObservableCollection<DrawerFile> DrawerFiles
        {
            get => _drawerFiles;
            set
            {
                _drawerFiles = value;
                OnPropertyChanged(nameof(DrawerFiles));
            }
        }

        public CreateEditDrawerViewModel(DrawerStore drawerStore,
            INavigationService closeModalNavigationService)
        {
            _drawerStore = drawerStore;

            Drawer = new Drawer();
            _drawerFiles = new ObservableCollection<DrawerFile>();

            _drawerStore.DrawerChanged += OnDrawerChanged;

            SaveDrawerCommand = new SaveDrawerCommand(drawerStore, closeModalNavigationService);
            CloseCreatorCommand = new CloseCreatorCommand(closeModalNavigationService);
            AddFilesCommand = new AddFilesCommand(_drawerStore);
        }

        private void OnDrawerChanged(Drawer drawer)
        {
            _drawer = drawer;
            DrawerFiles = new ObservableCollection<DrawerFile>(drawer.FileList);
        }

        public override void Dispose()
        {
            _drawerStore.DrawerAdded -= OnDrawerChanged;
            base.Dispose();
        }
    }
}
