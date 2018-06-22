using DLToolkit.Forms.Controls;
using SpotifyForms.Core.Services.Navigation;
using SpotifyForms.Core.ViewModels.Base;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SpotifyForms.Core
{
    public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
            FlowListView.Init();
            InitApp();
		}

		protected override async void OnStart ()
		{
            // Handle when your app starts
            await InitNavigation();
        }

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        private void InitApp()
        {
            ViewModelLocator.RegisterDependencies();
        }

        Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.NavigateToAsync<ViewModels.MainViewModel>();
        }
    }
}
