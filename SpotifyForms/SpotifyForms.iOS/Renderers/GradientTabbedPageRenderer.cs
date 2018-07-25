using System;
using CoreAnimation;
using CoreGraphics;
using SpotifyForms.Core.Views.Controls;
using SpotifyForms.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientTabbedPage), typeof(GradientTabbedPageRenderer))]
namespace SpotifyForms.iOS.Renderers
{
    public class GradientTabbedPageRenderer : TabbedRenderer
    {
        protected CAGradientLayer GradientLayer { get; set; }
        protected bool IsSetToolbar { get; set; }
        GradientTabbedPage GradientTabbedPage => (GradientTabbedPage)Element;
        IPageController PageController => (IPageController)Element;

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null && Element == null)
                return;

            GradientTabbedPage.CurrentPageChanged += (sender, args) => 
            {
                SetTabBar();
            };

            GradientLayer = new CAGradientLayer();
            GradientLayer.Colors = new CGColor[]
            {
                GradientTabbedPage.StartColor.ToCGColor(),
                GradientTabbedPage.EndColor.ToCGColor()
            };
            GradientLayer.Locations = new Foundation.NSNumber[] { 0.0, 1.0 };
            SetGradientOrientation();
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();
            SetTabBar();
        }

        void SetTabBar()
        {
            if (Element == null)
                return;
            
            TabBar.InvalidateIntrinsicContentSize();

            nfloat tabSize = 92f;

            UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

            if (UIInterfaceOrientation.LandscapeLeft == orientation || UIInterfaceOrientation.LandscapeRight == orientation)
            {
                tabSize = 48f;
            }

            CGRect tabFrame = TabBar.Frame;
            CGRect viewFrame = View.Frame;

            tabFrame.Height = tabSize;
            tabFrame.Y = View.Frame.Y;
            GradientLayer.Frame = tabFrame;
            TabBar.Frame = GradientLayer.Frame;
            TabBar.ContentMode = UIViewContentMode.Top;
            TabBar.Layer.InsertSublayer(GradientLayer, 0);

            //Set Tab indicator color for the selected Tab
            var indicatorWidth = TabBar.Frame.Width / TabBar.Items.Length;
            CGSize size = new CGSize(indicatorWidth, 3f);
            TabBar.SelectionIndicatorImage = ImageWithColor(size);

            PageController.ContainerArea = new Rectangle(0, tabFrame.Y + tabFrame.Height, viewFrame.Width, viewFrame.Height - tabFrame.Height);
            TabBar.SetNeedsUpdateConstraints();

            if (TabBar?.Items == null)
                return;

            // Go through TabBar items
            if (GradientTabbedPage != null)
            {
                for (int i = 0; i < TabBar.Items.Length; i++)
                    UpdateTabBarItem(TabBar.Items[i]);
            }
           
        }

        #region Helpers

        void UpdateTabBarItem(UITabBarItem item)
        {
            if (item == null)
                return;

            // Set the font for the title.
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("CircularSpotifyTxT-Bold", 13), TextColor = Color.FromHex("#686868").ToUIColor() }, UIControlState.Normal);
            item.SetTitleTextAttributes(new UITextAttributes() { Font = UIFont.FromName("CircularSpotifyTxT-Bold", 13), TextColor = Color.White.ToUIColor() }, UIControlState.Selected);

            // Moves the titles up just a bit.
            if (UIInterfaceOrientation.LandscapeLeft == UIApplication.SharedApplication.StatusBarOrientation 
                || UIInterfaceOrientation.LandscapeRight == UIApplication.SharedApplication.StatusBarOrientation)
            {
                item.TitlePositionAdjustment = new UIOffset(0f, -7f);
            }
            else
            {
                item.TitlePositionAdjustment = new UIOffset(0f, -13f);
            }

        }


        UIImage ImageWithColor(CGSize size)
        {
            UIView view = new UIView(new CGRect(TabBar.Frame.X, TabBar.Frame.Y, size.Width, TabBar.Frame.Height));
            UIImageView borderIndicator = new UIImageView(new CGRect(view.Frame.X, view.Frame.Size.Height-5, size.Width, size.Height));
            borderIndicator.BackgroundColor = GradientTabbedPage.BarIndicatorColor.ToUIColor();
            view.AddSubview(borderIndicator);

            UIGraphics.BeginImageContext(view.Bounds.Size);
            view.Layer.RenderInContext(UIGraphics.GetCurrentContext());
            UIImage image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return image;
        }


        void SetGradientOrientation()
        {
            if (GradientTabbedPage.Orientation == GradientOrientation.Horizontal)
            {
                GradientLayer.StartPoint = new CGPoint(0, 0);
                GradientLayer.EndPoint = new CGPoint(1, 0);
            }
            else if (GradientTabbedPage.Orientation == GradientOrientation.Vertical)
            {
                GradientLayer.StartPoint = new CGPoint(0.5, 0);
                GradientLayer.EndPoint = new CGPoint(0.5, 1);
            }
            else if (GradientTabbedPage.Orientation == GradientOrientation.TlBr)
            {
                GradientLayer.StartPoint = new CGPoint(0.35, 0);
                GradientLayer.EndPoint = new CGPoint(0.65, 0.8);
            }
            else if (GradientTabbedPage.Orientation == GradientOrientation.TrBl)
            {
                GradientLayer.StartPoint = new CGPoint(0, 0);
                GradientLayer.EndPoint = new CGPoint(0, 1);
            }
            else if (GradientTabbedPage.Orientation == GradientOrientation.BlTr)
            {
                GradientLayer.StartPoint = new CGPoint(0.75, 0.75);
                GradientLayer.EndPoint = new CGPoint(1, 0);
            }
            else if (GradientTabbedPage.Orientation == GradientOrientation.BrTl)
            {
                GradientLayer.StartPoint = new CGPoint(0.75, 0.75);
                GradientLayer.EndPoint = new CGPoint(0, 1);
            }
        }

        #endregion
    }
}
