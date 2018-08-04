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
            
            if (Device.RuntimePlatform == Device.Android)
            {
                if (e.ScrollY <= 90)
                {
                    if (!ToolbarItems.Contains(tbiSettings))
                        ToolbarItems.Add(tbiSettings);

                    gradientView.FadeTo(1.0, 400);
                }
                else
                {
                    if (ToolbarItems.Contains(tbiSettings))
                        ToolbarItems.Remove(tbiSettings);
                    
                    gradientView.FadeTo(-(int)((float)e.ScrollY / 5.5F), 400);
                }
            }
            else
            {
                if (e.ScrollY <= 20)
                {
                    if (!ToolbarItems.Contains(tbiSettings))
                        ToolbarItems.Add(tbiSettings);
                    
                    gradientView.FadeTo(1.0, 400);
                }
                else
                {
                    if (ToolbarItems.Contains(tbiSettings))
                        ToolbarItems.Remove(tbiSettings);
                    
                    gradientView.FadeTo(-(int)((float)e.ScrollY / 5.5F), 400);
                }
            }

        }
    }
}