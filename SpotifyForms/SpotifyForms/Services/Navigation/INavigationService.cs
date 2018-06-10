using SpotifyForms.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace SpotifyForms.Core.Services.Navigation
{
    public interface INavigationService
    {
        BaseViewModel PreviousPageViewModel { get; }
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();
        Task<bool> GoBackAsync(object parameter = null);
    }
}
