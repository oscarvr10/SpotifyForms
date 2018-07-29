using SpotifyForms.Core.Views.Controls;
using SpotifyForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BottomTabbedPage), typeof(ColoredTabBarRenderer))]
namespace SpotifyForms.iOS.Renderers
{
    public class ColoredTabBarRenderer : TabbedRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (TabBar == null)
                return;
            // Set our basic tab bar colors.

            TabBar.BarTintColor = Color.FromHex("#2d2d2d").ToUIColor();
            TabBar.TintColor = Color.FromHex("#ffffff").ToUIColor();
        }

        public override void ViewWillAppear(bool animated)
        {
            if (TabBar?.Items == null)
                return;

            // Go through our elements and change the icons
            var tabs = Element as BottomTabbedPage;
            if (tabs != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                    UpdateTabBarItem(TabBar.Items[i], tabs.Children[i].Icon);
            }

            base.ViewWillAppear(animated);
        }

        void UpdateTabBarItem(UITabBarItem item, string icon)
        {
            if (item == null || icon == null)
                return;

            // Set the font for the title.
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("CircularSpotifyTxT-Book", 11), TextColor = Color.FromHex("#adaeb2").ToUIColor() }, UIControlState.Normal);
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("CircularSpotifyTxT-Book", 11), TextColor = Color.FromHex("#ffffff").ToUIColor() }, UIControlState.Selected);

            // Moves the titles up just a bit.
            item.TitlePositionAdjustment = new UIOffset(0, -2);
        }
    }
}
