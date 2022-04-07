﻿namespace Infrastructure.ViewModels
{
    public class LayoutViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        public ViewModelBase ContentViewModel { get; }
        public LayoutViewModel(NavigationBarViewModel navigationBarViewModel, ViewModelBase contentViewModel)
        {
            NavigationBarViewModel = navigationBarViewModel;
            ContentViewModel = contentViewModel;
        }

        public override void Dispose()
        {
            ContentViewModel.Dispose(); 
            NavigationBarViewModel.Dispose();
            base.Dispose();
        }
    }
}