using SpotifyForms.Core.Views.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MyLibraryView : GradientTabbedPage
    {
		public MyLibraryView()
		{
			InitializeComponent();
        }
    }
}