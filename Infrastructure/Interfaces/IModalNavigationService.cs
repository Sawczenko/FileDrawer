using Infrastructure.ViewModels;

namespace Infrastructure.Interfaces
{
    public interface IModalNavigationService
    {
        void Navigate();
        void SetViewModel();
        void Close();
    }
}