﻿using System;
using System.DirectoryServices;
using DataStorage;
using DataStorage.Interfaces;
using DataStorage.Repositories;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;
using Infrastructure.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FileDrawer.Extensions
{
    public class DependencyInjectionProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceCollection _services;
        public IServiceProvider ServiceProvider;

        public DependencyInjectionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
            _services = new ServiceCollection();
            ServiceProvider = Build();
        }

        private IServiceProvider Build()
        {
            AddDatabase();
            AddStores();
            AddServices();
            AddViewModels();
            AddHomeNavigationService();
            AddMainWindow();
            return _services.BuildServiceProvider();
        }

        private void AddDatabase()
        {
            _services.AddDbContext<FileDrawerDbContext>(options =>
                options.UseSqlite(_configuration.GetConnectionString("FileDrawerDb")));
            _services.AddScoped<IFileRepository,FileRepository>();
            _services.AddScoped<IDrawerRepository,DrawerRepository>();
        }

        private void AddStores()
        {
            _services.AddSingleton<NavigationStore>();
            _services.AddSingleton<ModalNavigationStore>();
        }

        private void AddServices()
        {
            _services.AddTransient<CloseModalNavigationService>();
        }

        private void AddViewModels()
        {
            _services.AddTransient(s => new HomeViewModel());
            _services.AddTransient(s => new ManageDrawersViewModel(CreateNewDrawerModalNavigationService(s)));
            _services.AddTransient(s => new CreateNewDrawerViewModel(s.GetRequiredService<IDrawerRepository>(),CreateNewDrawerCloseModalNavigationService(s)));

            _services.AddSingleton<MainViewModel>();
            _services.AddSingleton(CreateNavigationBarViewModel);
        }

        private void AddMainWindow()
        {
            _services.AddSingleton(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });
        }

        private void AddHomeNavigationService()
        {
            _services.AddSingleton(CreateHomeNavigationService);
        }

        #region NavigationServices


        #region ModalNavigationServices

        private INavigationService CreateNewDrawerModalNavigationService(IServiceProvider serviceProvider)
        {
            return new ModalNavigationService<CreateNewDrawerViewModel>(
                serviceProvider.GetRequiredService<ModalNavigationStore>(),
                serviceProvider.GetRequiredService<CreateNewDrawerViewModel>);
        }

        private INavigationService CreateNewDrawerCloseModalNavigationService(IServiceProvider serviceProvider)
        {
            return new CloseModalNavigationService(serviceProvider.GetRequiredService<ModalNavigationStore>());
        }
        #endregion

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(CreateDrawerNavigationService(serviceProvider), CreateHomeNavigationService(serviceProvider));
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<NavigationBarViewModel>,
                serviceProvider.GetRequiredService<HomeViewModel>);
        }

        private INavigationService CreateDrawerNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ManageDrawersViewModel>(serviceProvider.GetRequiredService<NavigationStore>(),
                serviceProvider.GetRequiredService<NavigationBarViewModel>,
                serviceProvider.GetRequiredService<ManageDrawersViewModel>);
        }
        #endregion
    }
}