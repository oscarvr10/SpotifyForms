using SpotifyForms.Core.Models;
using System.Collections.Generic;
using System.Drawing;

namespace SpotifyForms.Core.Data
{
    public static class MockDataService
    {
        public static List<Playlist> GetPlaylists()
        {
            return new List<Playlist>
            {
                new Playlist(){ Name="Funk Rock", NrOfFollowers=49205, Editor="Spotify México", ImageUrl="https://i.scdn.co/image/a9cdead5cf5d85a33e7bc12b49d1006821650ca4"},
                new Playlist(){ Name="Rock Solid", NrOfFollowers=5025, Editor="Spotify México", ImageUrl="https://i.scdn.co/image/993ea43e0521938d5bf7a4fbe4f349acf6500975"},
                new Playlist(){ Name="This Is: Muse", NrOfFollowers=2140415, Editor="Spotify México", ImageUrl="https://i.scdn.co/image/3770c6d556b864e60684d0706013ff08dac76918"},
                new Playlist(){ Name="100% Scooter", NrOfFollowers=7447, Editor="Spotify México", ImageUrl="https://www.geek.com/wp-content/uploads/2015/11/dirty-dubstep-dangle.jpeg"},
                new Playlist(){ Name="Feeling Good, Feeling Great", NrOfFollowers=250211, Editor="Spotify México", ImageUrl="https://i.scdn.co/image/9c003edf2bcc3386c400d087b3bb4adb75ee1f5a"},
            };
        }

        public static List<Album> GetAlbums()
        {
            return new List<Album>
            {
                new Album(){ Artist="Royal Blood", Name="Royal Blood", ImageUrl="https://upload.wikimedia.org/wikipedia/en/b/b0/Royal_Blood_-_Royal_Blood_%28Artwork%29.jpg"},
                new Album(){ Artist="Fall Out Boy", Name="Infinity On High", ImageUrl="https://upload.wikimedia.org/wikipedia/en/6/69/Infinityonhigh.jpg"},
                new Album(){ Artist="Muse", Name="Drones", ImageUrl="https://upload.wikimedia.org/wikipedia/en/4/44/MuseDronesCover.jpg"},
                new Album(){ Artist="System Of A Down", Name="Mesmerize", ImageUrl="https://upload.wikimedia.org/wikipedia/en/0/02/Mezmerize-LP.jpg"},
                new Album(){ Artist="Muse", Name="Black Holes And Revelations", ImageUrl="https://upload.wikimedia.org/wikipedia/en/c/c5/BlackHolesCover.jpg"},
            };
        }

        public static List<Song> GetSongs()
        {
            return new List<Song>
            {
                new Song(){ Artist="Muse", Title="Dig Down", LengthInSeconds=228, AlbumImageUrl="https://i.scdn.co/image/08d56eac0c7d48bb8bf7752b2202c3314db79394"},
                new Song(){ Artist="Gorillaz", Title="Clint Eastwood", LengthInSeconds=341, AlbumImageUrl="https://i.scdn.co/image/6c6086f6922b9a44920310b34ef98161bd7adf78"},
                new Song(){ Artist="Jamiroquai", Title="Virtual Insanity", LengthInSeconds=229, AlbumImageUrl="https://i.scdn.co/image/bb3810cd18de42b93c54536d7e9ab7f8c10a8229"},
                new Song(){ Artist="Biffy Clyro", Title="The Captain", LengthInSeconds=223, AlbumImageUrl="https://i.scdn.co/image/f8d0b0bdf4a541fb2d13cb63e958aa760e3547e5"},
                new Song(){ Artist="System of a Down", Title="Hypnotize", LengthInSeconds=189, AlbumImageUrl="https://i.scdn.co/image/66eb75e0f3a8a91822ba7154e4b41066e63e51f2"},
                new Song(){ Artist="Paramore", Title="Hard Times", LengthInSeconds=182, AlbumImageUrl="https://i.scdn.co/image/d8296568ae1b856050976111fa892d8db693efd5"}
            };
        }

        public static List<Artist> GetArtists()
        {
            return new List<Artist>
            {
                new Artist(){ Name="Royal Blood", ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQxhKmcz7n60OYILafTuVWtbfgESW-k7g0l3tHyfY6fLzF19rMFtg"},
                new Artist(){ Name="The Beatles", ImageUrl="http://www.popscoop.org/wp-content/uploads/2015/12/Beatles.jpg-392x300.jpg"},
                new Artist(){ Name="Daft Punk", ImageUrl="http://netstorage.metrolyrics.com/blog/wp-content/uploads/2013/08/DP_Image.jpg"},
                new Artist(){ Name="The Weeknd", ImageUrl="http://www.planocritico.com/wp-content/uploads/2015/09/the-weeknd-bbtm-600x400.jpg"},
                new Artist(){ Name="Muse", ImageUrl="https://pl.scdn.co/images/pl/default/c44c0da53b03b18dd3fdaf91a7cb297e96e96491"},
            };
        }

        public static List<Podcast> GetPodcasts()
        {
            return new List<Podcast>
            {
                new Podcast(){ Name="Here For The Boos", Author="Spotify Radio", ImageUrl="http://myspotifyideas.com/images/2d9ba6aff299c69cb7b145e4c2b14b120cbdef5b-284.jpeg"},
                new Podcast(){ Name="Dressed: The History of Fashion",Author="Fashion Stories", ImageUrl="http://myspotifyideas.com/images/83fb620984c2332a9e526a322a547668a8d658ee-265.jpeg"},
                new Podcast(){ Name="Make Me Smart", Author="Kai and Molly", ImageUrl="http://myspotifyideas.com/images/0185d72c914bbd6bc6cebdf38925bb4a72201b07-265.jpeg"},
                new Podcast(){ Name="In Our Time", Author="BBC Radio", ImageUrl="http://myspotifyideas.com/images/3f8660b8172c3692f90af57846fcea239750d5f3-265.jpeg"},
                new Podcast(){ Name="Every Little Thing", Author="Gimlet", ImageUrl="http://myspotifyideas.com/images/5fc8c46b290ab7272020843c3669d29175f0a7e4-265-1.jpeg"},
            };
        }

        public static List<SearchCategory> GetSearchCategories()
        {
            return new List<SearchCategory>
            {
                new SearchCategory(){ Name="New Releases", StartColor = Color.DarkBlue, EndColor=Color.DarkRed },
                new SearchCategory(){ Name="Charts", StartColor = Color.DarkBlue, EndColor=Color.DarkOliveGreen},
                new SearchCategory(){ Name="Podcasts", StartColor = Color.LightPink, EndColor=Color.Orange},
                new SearchCategory(){ Name="Latin", StartColor = Color.LightBlue, EndColor=Color.Blue},
                new SearchCategory(){ Name="Pop", StartColor = Color.Purple, EndColor=Color.MediumVioletRed},
                new SearchCategory(){ Name="Decades", StartColor = Color.Pink, EndColor=Color.HotPink},
                new SearchCategory(){ Name="Sleep", StartColor = Color.MediumPurple, EndColor=Color.LightPink},
                new SearchCategory(){ Name="Focus", StartColor = Color.Green, EndColor=Color.GreenYellow},
                new SearchCategory(){ Name="Romance", StartColor = Color.Gray, EndColor=Color.DarkRed},
                new SearchCategory(){ Name="Comedy", StartColor = Color.DarkBlue, EndColor=Color.LightGray},
                new SearchCategory(){ Name="Dinner", StartColor = Color.DarkRed, EndColor=Color.DarkOrange},
                new SearchCategory(){ Name="Sleep", StartColor = Color.YellowGreen, EndColor=Color.Yellow},
                new SearchCategory(){ Name="Rock", StartColor = Color.DarkBlue, EndColor=Color.DarkRed},
                new SearchCategory(){ Name="Indie", StartColor = Color.DarkBlue, EndColor=Color.DarkRed},
                new SearchCategory(){ Name="Punk", StartColor = Color.DarkBlue, EndColor=Color.DarkRed},
                new SearchCategory(){ Name="Electronic/Dance", StartColor = Color.DarkBlue, EndColor=Color.DarkRed},
            };
        }
    }
}
