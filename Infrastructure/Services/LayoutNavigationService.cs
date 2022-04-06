using System;
using Infrastructure.Interfaces;
using Infrastructure.Stores;
using Infrastructure.ViewModels;

namespace Infrastructure.Services
{
    public class LayoutNavigationService<TViewModel> : INavigationService<TViewModel> where TViewModel:ViewModelBase
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