using System.Windows.Input;
using DataStorage.Interfaces;
using Infrastructure.Commands.Navigation;
using Infrastructure.Interfaces;

namespace Infrastructure.ViewModels
{
    public class EditDrawerViewModel : ViewModelBase
    {
        private readonly IDrawerRepository _drawerRepository;

        public ICommand CloseEditorCommand { get; }

        public EditDrawerViewModel(IDrawerRepository drawerRepository,INavigationService closeModalNavigationService)
        {
            _drawerRepository = drawerRepository;
            CloseEditorCommand = new ModalNavigateCommand(closeModalNavigationService);
        }
    }
}