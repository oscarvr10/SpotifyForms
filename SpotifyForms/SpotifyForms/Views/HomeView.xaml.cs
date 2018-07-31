using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		public HomeView()
		{
			InitializeComponent();
		}

        void mainScrollView_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (gradientView.Height <= 0)
                return;

            gradientView.TranslationY = -(int)((float)e.ScrollY / 3.5F);
        }
    }
}