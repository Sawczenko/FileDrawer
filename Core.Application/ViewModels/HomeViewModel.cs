using System.Collections.Generic;
using Core.Application.Stores;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Core.Application.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly DrawerStore _drawerStore;

        public HomeViewModel(DrawerStore drawerStore)
        {
            ViewModels = new List<DrawerViewModel>();

            _drawerStore = drawerStore;

            CreateViewModelsForDrawers();
        }

        private void CreateViewModelsForDrawers()
        {
            var drawers = _drawerStore.GetDrawers();

            foreach (var drawer in drawers)
            {
                ViewModels.Add(new DrawerViewModel(drawer));
            }
        }

        public List<DrawerViewModel> ViewModels { get; set; }
    }
}