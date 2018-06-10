using SpotifyForms.Core.Models;
using SpotifyForms.Core.ViewModels.Base;
using System;
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

        #endregion

        #region Commands
        public ICommand NavigateToMyLibraryCommand { get; set; }

        #endregion
        public MainViewModel()
        {
            SetCommands();
        }

        void SetCommands()
        {
            NavigateToMyLibraryCommand = new Command(async() => await NavigateToMyLibrary());
        }

        
        #region Base Methods

        public override Task InitializeAsync(object navigationData)
        {
            return base.InitializeAsync(navigationData);
        }

        #endregion


        #region Command Methods

        private async Task NavigateToMyLibrary()
        {
            await NavigationService.NavigateToAsync<MyLibraryViewModel>();
        }

        #endregion

    }
}
