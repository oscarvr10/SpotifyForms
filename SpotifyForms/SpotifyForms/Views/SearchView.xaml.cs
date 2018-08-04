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
            //Needs to be reworked because it doesn't work very well on both platforms
            /*if (Device.RuntimePlatform == Device.Android)
            {
                double headerHeight = 100;

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
            }*/
            if(Device.RuntimePlatform == Device.Android)
            {
                if (e.ScrollY <= 25)
                    gradientView.FadeTo(1.0, 400);
                else
                    gradientView.FadeTo(-(int)((float)e.ScrollY / 5.5F), 400);
            }
            else
            {
                if (e.ScrollY <= 5)
                    gradientView.FadeTo(1.0, 400);
                else
                    gradientView.FadeTo(-(int)((float)e.ScrollY / 5.5F), 400);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Because the ListView is within ScrollView
            //We manually set the StackLayout Height that contains the mentioned ListView, in order ScrollView can be scrolled until to the bottom

            if (Device.RuntimePlatform == Device.Android)
            {
                stkContainer.HeightRequest = GetGridContainerHeight((double)flvCategories.FlowItemsSource.Count,
                                                                    (double)flvCategories.FlowColumnCount,
                                                                    flvCategories.RowHeight + 40);
            }
            else
            {
                stkContainer.HeightRequest = GetGridContainerHeight((double)flvCategories.FlowItemsSource.Count,
                                                                    (double)flvCategories.FlowColumnCount,
                                                                    flvCategories.RowHeight + 20);
            }
            
        }
        public static double GetGridContainerHeight(double itemCount, double columnCount, int rowHeight) 
        { 
            var rowCount = Math.Round(itemCount / columnCount); 
            return rowCount * rowHeight; 
        }
    }
}