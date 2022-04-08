using System.Windows.Input;
using Infrastructure.Commands;
using Infrastructure.Commands.DrawerCommands;
using Infrastructure.Commands.NavigateCommands;
using Infrastructure.Services;
using Infrastructure.Stores;

namespace Infrastructure.ViewModels
{
    public class ManageDrawersViewModel : ViewModelBase
    {
        public ICommand AddNewDrawerCommand { get; }
        public ManageDrawersViewModel()
        {
            AddNewDrawerCommand = new AddNewDrawerCommand();
        }
    }
}