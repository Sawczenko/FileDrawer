using System;
using System.DirectoryServices;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;
using Infrastructure.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FileDrawer.Extensions
{
    public class DependencyInjectionExtensions
    {

        private IServiceProvider _serviceProvider;
        private readonly IServiceCollection _services;

        public DependencyInjectionExtensions()
        {
            _services = new ServiceCollection();
        }

        public IServiceProvider Build()
        {
            AddStores();
            AddViewModels();
            AddHomeNavigationService();
            AddMainWindow();
            return _serviceProvider = _services.BuildServiceProvider();
        }

        private void AddStores()
        {
            _services.AddSingleton<NavigationStore>();
            _services.AddSingleton<ModalNavigationStore>();
        }

        private void AddViewModels()
        {
            _services.AddTransient(s => new HomeViewModel());
            _services.AddTransient(s => new ManageDrawersViewModel());
            _services.AddSingleton<MainViewModel>();
            _services.AddSingleton<NavigationBarViewModel>(CreateNavigationBarViewModel);
        }

        private void AddMainWindow()
        {
            _services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }

        private void AddHomeNavigationService()
        {
            _services.AddSingleton<INavigationService>(CreateHomeNavigationService);
        }

        #region NavigationServices

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(CreateDrawerNavigationService(serviceProvider), CreateHomeNavigationService(serviceProvider));
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(_serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<NavigationBarViewModel>,
                serviceProvider.GetRequiredService<HomeViewModel>);
        }

        private INavigationService CreateDrawerNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ManageDrawersViewModel>(_serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<NavigationBarViewModel>,
                serviceProvider.GetRequiredService<ManageDrawersViewModel>);
        }

        #endregion
    }
}