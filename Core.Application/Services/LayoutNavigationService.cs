using System;
using Core.Application.Interfaces;
using Core.Application.Stores;
using Core.Application.ViewModels;

namespace Core.Application.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService where TViewModel:ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TViewModel> _createViewModel;
        private readonly Func<NavigationBarViewModel> _createNavigationBarViewModel;

        public LayoutNavigationService(NavigationStore navigationStore, Func<NavigationBarViewModel> navigationBarViewModel,Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createNavigationBarViewModel = navigationBarViewModel;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _navigationStore.CurrentViewModel = new LayoutViewModel(_createNavigationBarViewModel(), _createViewModel());
        }
    }
}