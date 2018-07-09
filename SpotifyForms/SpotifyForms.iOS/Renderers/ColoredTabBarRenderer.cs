﻿using SpotifyForms.Core.Views.Controls;
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

            // Set our basic tab bar colors.
            //UITabBar.Appearance.BarTintColor = Color.FromHex("#1e1e1e").ToUIColor();
            UITabBar.Appearance.TintColor = Color.FromHex("#ffffff").ToUIColor();
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

        private void UpdateTabBarItem(UITabBarItem item, string icon)
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
