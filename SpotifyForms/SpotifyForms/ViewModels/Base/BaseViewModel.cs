using SpotifyForms.Core.Services.Navigation;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpotifyForms.Core.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; }
        }

        protected readonly INavigationService NavigationService;
        public ICommand GoBackCommand { get; set; }

        #endregion
        public BaseViewModel()
        {
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
            GoBackCommand = new Command(async () => await GoBackAsync());
        }

        async Task GoBackAsync()
        {
            try
            {
                await NavigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
