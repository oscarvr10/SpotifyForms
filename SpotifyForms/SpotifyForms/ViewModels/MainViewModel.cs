using SpotifyForms.Core.Models;
using SpotifyForms.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SpotifyForms.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        public List<Album> Albums { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Song> Songs { get; set; }

        #endregion

        #region Commands
        

        #endregion
        public MainViewModel()
        {

        }


        #region Base Methods

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        #endregion


        #region Command Methods
        
        #endregion

    }
}
