using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpotifyForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SearchView : ContentPage
	{
		public SearchView()
		{
			InitializeComponent();
		}

        void Handle_Scrolled(object sender, Xamarin.Forms.ScrolledEventArgs e)
        {
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Because the ListView is within ScrollView
            //We set the Height of StackLayout that contains the mentioned ListView, in order ScrollView can be scrolled
            stkContainer.HeightRequest = GetGridContainerHeight((double)flvCategories.FlowItemsSource.Count, 
                                                                (double)flvCategories.FlowColumnCount, 
                                                                flvCategories.RowHeight) + 80;
            
        }
        public static double GetGridContainerHeight(double itemCount, double columnCount, int rowHeight) 
        { 
            var rowCount = Math.Ceiling(itemCount / columnCount); 
            return rowCount * rowHeight; 
        }
    }
}