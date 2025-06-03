using TypeMaster.Helpers;

namespace TypeMaster.Services
{
    public interface INavigationService
    {
        BaseViewModel CurrentViewModel { get; set; }
    }
}