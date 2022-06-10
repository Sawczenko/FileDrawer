using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Commands.ManageDrawers.EditDrawersCommands;
using Infrastructure.Commands.Navigation;
using Infrastructure.Interfaces;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
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

        private readonly IDrawerRepository _drawerRepository;
        private readonly DrawerStore _editDrawerStore;
        
        public EditDrawerViewModel(IDrawerRepository drawerRepository,INavigationService closeModalNavigationService, DrawerStore editDrawerStore)
        {
            _drawer = new Drawer();
            _drawerFiles = new ObservableCollection<DrawerFile>();
            _drawerRepository = drawerRepository;
            _editDrawerStore = editDrawerStore;
            CloseEditorCommand = new ModalNavigateCommand(closeModalNavigationService);
            AddFilesCommand = new AddFilesCommand(drawerRepository,DrawerFiles);
            PrepareView();
        }

        private void PrepareView()
        {
            Drawer = _editDrawerStore.Drawer;
            ObservableCollection<DrawerFile> drawerFiles =
                new ObservableCollection<DrawerFile>(Drawer.FileList);
            DrawerFiles = drawerFiles;
        }

    }
}