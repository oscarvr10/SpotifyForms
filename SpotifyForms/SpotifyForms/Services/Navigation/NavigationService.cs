using SpotifyForms.Core.ViewModels.Base;
using SpotifyForms.Core.Views;
using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpotifyForms.Core.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        /// <summary>
        /// Gets the previous ViewModel that was navigated.
        /// </summary>
        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        /// <summary>
        /// Performs hierarchical navigation to a specified page.
        /// </summary>
        /// <typeparam name="TViewModel">The ViewModel</typeparam>
        /// <returns></returns>
        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }


        /// <summary>
        /// Performs hierarchical navigation to a specified page, passing a parameter.
        /// </summary>
        /// <typeparam name="TViewModel">The ViewModel</typeparam>
        /// <param name="parameter">The parameters to send</param>
        /// <returns></returns>
        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }


        /// <summary>
        /// Removes the last page from the navigation stack.
        /// </summary>
        /// <returns></returns>
        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 1]);
            }

            return Task.FromResult(true);
        }


        /// <summary>
        /// Removes all the previous pages from the navigation stack.
        /// </summary>
        /// <returns></returns>
        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }


        /// <summary>
        /// Navigates to the previous page from navigation stack.
        /// </summary>
        /// <returns></returns>
        public Task<bool> GoBackAsync(object parameter = null)
        {
            return InternalGoBackAsync(parameter);
        }


        #region Internal Methods

        /// <summary>
        /// Performs navigation to a specified ViewModel.
        /// </summary>
        /// <param name="viewModelType">The ViewModel type</param>
        /// <param name="parameter">Parameters to send</param>
        /// <returns></returns>
        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);

            var navigationPage = Application.Current.MainPage as CustomNavigationView;

            if (navigationPage != null)
                await navigationPage.PushAsync(page);
            else
                Application.Current.MainPage = new CustomNavigationView(page);

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }


        /// <summary>
        /// Gets the Type from specific ViewModel using reflection.
        /// </summary>
        /// <param name="viewModelType">The ViewModel type</param>
        /// <returns></returns>
        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }


        /// <summary>
        /// Creates a Page by its specific ViewModel.
        /// </summary>
        /// <param name="viewModelType">The ViewModel type</param>
        /// <param name="parameter">The parameters to send</param>
        /// <returns></returns>
        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
                throw new Exception($"Cannot locate page type for {viewModelType}");

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }


        /// <summary>
        /// Performs navigation to the last Page from navigation stack.
        /// </summary>
        /// <param name="viewModelType">The ViewModel type</param>
        /// <param name="parameter">Parameters to send</param>
        /// <returns></returns>
        private async Task<bool> InternalGoBackAsync(object parameter)
        {
            var navigationPage = Application.Current.MainPage as CustomNavigationView;

            if (navigationPage != null)
            {
                await RemoveLastFromBackStackAsync();
                return true;
            }

            return false;
        }
        #endregion
    }
}
