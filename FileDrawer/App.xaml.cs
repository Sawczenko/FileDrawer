using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Core.Application.Interfaces;
using FileDrawer.Components.Modal;
using FileDrawer.Extensions;
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

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message + "\n" + e.Exception.StackTrace, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

    }
}
