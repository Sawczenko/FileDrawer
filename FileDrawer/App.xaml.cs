using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;


namespace FileDrawer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly DependencyInjectionProvider _dependencyInjectionProvider;

        public App()
        {
            _dependencyInjectionProvider = new DependencyInjectionProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var homeNavigationService = _dependencyInjectionProvider.ServiceProvider.GetRequiredService<INavigationService>();
            homeNavigationService.Navigate();
            MainWindow = _dependencyInjectionProvider.ServiceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }
        
    }
}
