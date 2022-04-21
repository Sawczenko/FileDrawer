using System.Windows.Input;
using Infrastructure.Commands;
using Infrastructure.Commands.Navigation;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
{
    public class ManageDrawersViewModel : ViewModelBase
    {
        public ICommand AddNewDrawerCommand { get; }

        public ManageDrawersViewModel(INavigationService modalNavigationService)
        {
            AddNewDrawerCommand = new ModalNavigateCommand(modalNavigationService);
        }
    }
}