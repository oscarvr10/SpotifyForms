
using Xamarin.Forms;

namespace SpotifyForms.Core.Views.Controls
{
    public class ModalPage : ContentPage
	{
        public static readonly BindableProperty SubtitleProperty =
            BindableProperty.Create(nameof(Subtitle), typeof(string), typeof(HorizontalScrollView), default(string));

        public string Subtitle
        {
            get { return (string)GetValue(SubtitleProperty); }
            set { SetValue(SubtitleProperty, value); }
        }

        public ModalPage()
        {
            if (Device.RuntimePlatform == Device.Android)
                NavigationPage.SetHasNavigationBar(this, false);
        }
    }
}