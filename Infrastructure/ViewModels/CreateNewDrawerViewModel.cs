using System.Windows.Input;
using Infrastructure.Commands.Drawers.CreateNewDrawerCommands;
using Infrastructure.Interfaces;

namespace Infrastructure.ViewModels
{
    public class CreateNewDrawerViewModel : ViewModelBase
    {
        public ICommand SaveDrawerCommand { get; }
        public CreateNewDrawerViewModel(INavigationService closeModalNavigationService)
        {
            SaveDrawerCommand = new SaveDrawerCommand(closeModalNavigationService);
        }
    }
}