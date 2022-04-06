using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;
using Infrastructure.ViewModels;

namespace FileDrawer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private readonly NavigationStore _navigationStore;
        public App()
        {
            _navigationStore = new NavigationStore();
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(CreateDrawerNavigationService(), CreateHomeNavigationService());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var homeNavigationService = CreateHomeNavigationService();
            homeNavigationService.Navigate();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private INavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(_navigationStore,
                CreateNavigationBarViewModel,
                () => new HomeViewModel());
        }

        private INavigationService<CreateDrawerViewModel> CreateDrawerNavigationService()
        {
            return new LayoutNavigationService<CreateDrawerViewModel>(_navigationStore,
                CreateNavigationBarViewModel,
                () => new CreateDrawerViewModel());
        }

    }
}
