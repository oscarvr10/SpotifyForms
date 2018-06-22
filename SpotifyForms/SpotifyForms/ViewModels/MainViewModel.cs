using SpotifyForms.Core.Data;
using SpotifyForms.Core.Models;
using SpotifyForms.Core.ViewModels.Base;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpotifyForms.Core.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Properties

        public List<Album> Albums { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Podcast> Podcasts { get; set; }
        public List<SearchCategory> SearchCategories { get; set; }
        #endregion

        #region Commands
        public ICommand NavigateToAlbumDetailCommand { get; set; }

        #endregion
        public MainViewModel()
        {
            SetCommands();
            InitData();
        }

        void SetCommands()
        {
            NavigateToAlbumDetailCommand = new Command(async() => await NavigateToAlbumDetail());
        }

        void InitData()
        {
            Albums = MockDataService.GetAlbums();
            Playlists = MockDataService.GetPlaylists();
            Songs = MockDataService.GetSongs();
            Artists = MockDataService.GetArtists();
            Podcasts = MockDataService.GetPodcasts();
            SearchCategories = MockDataService.GetSearchCategories();
        }
        
        
        #region Base Methods

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        #endregion


        #region Command Methods

        private async Task NavigateToAlbumDetail()
        {
            await NavigationService.NavigateToAsync<AlbumDetailViewModel>();
        }

        #endregion

    }
}
