using SpotifyForms.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpotifyForms.Core.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region Properties

        bool openingPage;

        public List<Album> Albums { get; set; }
        public List<Playlist> Playlists { get; set; }
        public List<Song> Songs { get; set; }

        #endregion

        #region Commands

        ICommand openPlayerCommand;
        public ICommand OpenPlayerCommand
        {
            get
            {
                return openPlayerCommand ?? (openPlayerCommand = new Command<Song>(async (item) => await OpenPlayer(item), (arg) => !openingPage));
            }
        }

        #endregion
        public HomeViewModel()
        {

        }

        async Task OpenPlayer(Song item)
        {

        }

    }
}
