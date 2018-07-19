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

        void Handle_Scrolled(object sender, ScrolledEventArgs e)
        {
            if (gradientView.Height <= 0)
                return;

            var gradientViewHeight = gradientView.Height * 0.8;
            var scrollRegion = (mainGrid.Height + 50) - mainScrollView.Height;
            var parallexRegion = gradientViewHeight - mainScrollView.Height;
            double scrollY = mainScrollView.ScrollY;
            if(scrollY < -90)
                scrollY = -90;
            
            gradientView.TranslationY = mainScrollView.ScrollY - parallexRegion * (scrollY / scrollRegion); 
        }
    }
}