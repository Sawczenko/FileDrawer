using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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
        private readonly NavigationBarViewModel _navigationBarViewModel;

        public App()
        {
            _navigationStore = new NavigationStore();
            _navigationBarViewModel = new NavigationBarViewModel(CreateDrawerNavigationService(),CreateHomeNavigationService());
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

        private NavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new NavigationService<HomeViewModel>(_navigationStore,
                () => new HomeViewModel( _navigationBarViewModel));
        }

        private NavigationService<CreateDrawerViewModel> CreateDrawerNavigationService()
        {
            return new NavigationService<CreateDrawerViewModel>(_navigationStore,
                () => new CreateDrawerViewModel(_navigationBarViewModel));
        }

    }
}
