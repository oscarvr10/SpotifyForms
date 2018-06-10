using SpotifyForms.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace SpotifyForms.Core.ViewModels
{
    public class MyLibraryViewModel : BaseViewModel
    {
        public MyLibraryViewModel()
        {

        }

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }
    }
}
