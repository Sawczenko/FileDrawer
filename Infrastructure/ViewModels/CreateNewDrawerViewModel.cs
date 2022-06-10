﻿using System;
using System.Windows.Input;
using Core.Entities;
using DataStorage.Interfaces;
using Infrastructure.Commands.ManageDrawers.CreateNewDrawerCommands;
using Infrastructure.Interfaces;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
{
    public class CreateNewDrawerViewModel : ViewModelBase
    {
        private readonly DrawerStore _drawerStore;
        public ICommand SaveDrawerCommand { get; }
        public ICommand CloseCreatorCommand { get; }
        

        private Drawer _drawer;
        public Drawer Drawer
        {
            get => _drawer;
            set => _drawer = value;
        }

        public CreateNewDrawerViewModel(DrawerStore drawerStore,
        INavigationService closeModalNavigationService)
        {
            _drawerStore = drawerStore;
            _drawer = new Drawer();
            SaveDrawerCommand = new SaveDrawerCommand(drawerStore,closeModalNavigationService);
            CloseCreatorCommand = new CloseCreatorCommand(closeModalNavigationService);
        }

    }
}