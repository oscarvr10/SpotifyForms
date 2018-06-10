using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SpotifyForms.Core.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Properties

        string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; }
        }


        #endregion
        public BaseViewModel()
        {

        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
    }
}
