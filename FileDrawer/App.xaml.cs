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
        private readonly IConfiguration _configuration;

        public App()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configuration = builder.Build();

            _dependencyInjectionProvider = new DependencyInjectionProvider(_configuration);
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
