using System;
using Core.Application.Interfaces;
using Core.Application.Stores;
using Core.Application.ViewModels;

namespace Core.Application.Services
{
    public class ModalNavigationService<TViewModel> : INavigationService where TViewModel: ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly Func<TViewModel> _createViewModel;

        public ModalNavigationService(ModalNavigationStore modalNavigationStore, Func<TViewModel> createViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            _createViewModel = createViewModel;
        }

        public void Navigate()
        {
            _modalNavigationStore.CurrentViewModel = _createViewModel();
        }
    }
}