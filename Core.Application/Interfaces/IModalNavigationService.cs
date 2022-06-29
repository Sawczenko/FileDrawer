namespace Core.Application.Interfaces
{
    public interface IModalNavigationService
    {
        void Navigate();
        void SetViewModel();
        void Close();
    }
}