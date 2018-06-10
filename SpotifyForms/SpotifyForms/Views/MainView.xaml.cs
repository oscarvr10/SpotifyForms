using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : TabbedPage
	{
		public MainView()
		{
			InitializeComponent();
		}
	}
}