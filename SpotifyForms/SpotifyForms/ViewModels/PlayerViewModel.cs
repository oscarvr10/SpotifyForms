using SpotifyForms.Core.Models;
using SpotifyForms.Core.ViewModels.Base;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpotifyForms.Core.ViewModels
{
    public class PlayerViewModel : BaseViewModel
    {
        #region Properties

        private bool _isPlaying;
        public bool IsPlaying
        {
            get { return _isPlaying; }
            set { _isPlaying = value; OnPropertyChanged(); }
        }
        

        private int _ticks;
        public int Ticks
        {
            get { return _ticks; }
            set { _ticks = value; OnPropertyChanged(); }
        }

        int _ticksLeft;
        public int TicksLeft
        {
            get { return _ticksLeft; }
            set { _ticksLeft = value; OnPropertyChanged(); }
        }

        private Song song;
        public Song Song
        {
            get { return song; }
            set { song = value; OnPropertyChanged(); }
        }
        
        #endregion
        
        public PlayerViewModel()
        {
        }

        #region Commands

        ICommand playCommand;
        public ICommand PlayCommand
        {
            get
            {
                return playCommand ?? (playCommand = new Command(() => StartStopPlaying()));
            }
        }
        #endregion

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData is Song)
                Song = navigationData as Song;

            TicksLeft = Song.LengthInSeconds;
            return base.InitializeAsync(navigationData);
        }

        private void StartStopPlaying()
        {
            if (!IsPlaying)
            {
                IsPlaying = true;

                Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                {
                    Ticks += 1;

                    TicksLeft = Song.LengthInSeconds - Ticks;
                    // Stop playing when at the end.
                    if (Ticks == Song.LengthInSeconds)
                        IsPlaying = false;

                    // While the song is not over, return true for another tick.
                    return Ticks <= Song.LengthInSeconds && IsPlaying;
                });
            }
            else
            {
                // If it is currently playing, set it to false.
                IsPlaying = false;
            }
        }
    }
}
