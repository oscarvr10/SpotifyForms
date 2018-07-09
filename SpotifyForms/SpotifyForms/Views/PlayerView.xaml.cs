using SpotifyForms.Core.Views.Controls;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PlayerView : ModalPage
	{
		public PlayerView()
		{
			InitializeComponent();
            artwork.On<iOS>().UseBlurEffect(BlurEffectStyle.Dark);
        }
	}
}