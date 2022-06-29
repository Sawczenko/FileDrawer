using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Core.Application.Commands.ManageDrawers.EditDrawersCommands;
using Core.Application.Commands.Navigation;
using Core.Application.Interfaces;
using Core.Application.Stores;
using Core.Entities.Entities;
using Infrastructure.Persistence.Interfaces;

namespace Core.Application.ViewModels
{
    public class EditDrawerViewModel : ViewModelBase
    {
        public ICommand CloseEditorCommand { get; }
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

        private readonly DrawerStore _drawerStore;
        
        public EditDrawerViewModel(INavigationService closeModalNavigationService, DrawerStore drawerStore)
        {
            _drawerFiles = new ObservableCollection<DrawerFile>();
            _drawerStore = drawerStore;
            _drawer = _drawerStore.GetSelectedDrawer();
            CloseEditorCommand = new ModalNavigateCommand(closeModalNavigationService);
            AddFilesCommand = new AddFilesCommand(_drawerStore);
            _drawerStore.DrawerChanged += OnDrawerChanged;
            PrepareView();
        }

        public override void Dispose()
        {
            _drawerStore.DrawerAdded -= OnDrawerChanged;
            base.Dispose();
        }

        private void OnDrawerChanged(Drawer drawer)
        {
            _drawer = drawer;
            DrawerFiles = new ObservableCollection<DrawerFile>(drawer.FileList);
        }

        private void PrepareView()
        {
            Drawer = _drawerStore.GetSelectedDrawer();
            ObservableCollection<DrawerFile> drawerFiles =
                new ObservableCollection<DrawerFile>(Drawer.FileList);
            DrawerFiles = drawerFiles;
        }

    }
}