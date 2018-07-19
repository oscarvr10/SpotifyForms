using SpotifyForms.Core.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainView : BottomTabbedPage
	{
        public MainView()
        {
            InitializeComponent();

            // Hide the navbar on Android
            if (Device.RuntimePlatform == Device.Android)
            {
                //NavigationPage.SetHasNavigationBar(this, false);
                BarTextColor = Color.FromHex("#adaeb2");
            }

            On<Android>().SetBarItemColor(Color.FromHex("#adaeb2"));
            On<Android>().SetBarSelectedItemColor(Color.White);
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
	}
}