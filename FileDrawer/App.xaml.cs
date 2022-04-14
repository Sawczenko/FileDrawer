using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DataStorage;
using FileDrawer.Components.Modal;
using FileDrawer.Extensions;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;
using Infrastructure.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace FileDrawer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            DependencyInjectionExtensions dependencyInjectionExtensions =
                new DependencyInjectionExtensions();

            _serviceProvider = dependencyInjectionExtensions.Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var homeNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            homeNavigationService.Navigate();
            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
        
    }
}
