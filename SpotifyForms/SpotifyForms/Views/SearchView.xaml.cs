using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchView : ContentPage
	{
        SearchBar searchBar;

		public SearchView()
		{
			InitializeComponent();
            searchBar = new SearchBar
            {
                BackgroundColor = Color.White,
                HeightRequest = 60,
                VerticalOptions = LayoutOptions.Start,
                TextColor = Color.Gray,
                Placeholder = "Artists, songs or podcasts",
                Margin = new Thickness(20,25),
            };
            searchBar.FontSize = Device.GetNamedSize(NamedSize.Medium, searchBar);
		}

        void mainScrollView_Scrolled(object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            double headerHeight = 100;

            //if (e.ScrollY <= 0)
            //{
            //    mainScrollView.TranslationY = 0;
            //    if (gridContainer.Children.Contains(searchBar))
            //    {
            //        var index = gridContainer.Children.IndexOf(searchBar);
            //        gridContainer.Children.RemoveAt(index);
            //    }
            //}
            if (e.ScrollY <= (headerHeight * 2))
            {
                if (gridContainer.Children.Contains(searchBar))
                {
                    var index = gridContainer.Children.IndexOf(searchBar);
                    gridContainer.Children.RemoveAt(index);
                }

                mainScrollView.TranslationY = 0;
            }
            else if (e.ScrollY > (headerHeight * 2)) //scrolled 
            {
                if (!gridContainer.Children.Contains(searchBar))
                    gridContainer.Children.Add(searchBar);

                mainScrollView.TranslationY = headerHeight;
            }

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Because the ListView is within ScrollView
            //We set the Height of StackLayout that contains the mentioned ListView, in order ScrollView can be scrolled
            stkContainer.HeightRequest = GetGridContainerHeight((double)flvCategories.FlowItemsSource.Count, 
                                                                (double)flvCategories.FlowColumnCount, 
                                                                flvCategories.RowHeight) + 100;
            
        }
        public static double GetGridContainerHeight(double itemCount, double columnCount, int rowHeight) 
        { 
            var rowCount = Math.Ceiling(itemCount / columnCount); 
            return rowCount * rowHeight; 
        }
    }
}