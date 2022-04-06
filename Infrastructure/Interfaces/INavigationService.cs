using Infrastructure.ViewModels;

namespace Infrastructure.Interfaces
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}