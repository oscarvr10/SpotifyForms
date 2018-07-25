using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.Design.Widget;
using Android.Views;
using SpotifyForms.Core.Views.Controls;
using SpotifyForms.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(GradientTabbedPage), typeof(GradientTabbedPageRenderer))]
namespace SpotifyForms.Droid.Renderers
{
    public class GradientTabbedPageRenderer : TabbedPageRenderer
    {
        GradientDrawable gradient;

        public GradientTabbedPageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null && Element == null)
                return;
            
            var context = (MainActivity)this.Context;

            var tablayout = this.FindViewById<TabLayout>(Resource.Id.sliding_tabs);
            gradient = new GradientDrawable();

            SetGradientOrientation();

            //Set gradient to Tablayout
            tablayout.SetBackground(gradient);
            var window = context.Window;
            window.AddFlags(WindowManagerFlags.TranslucentStatus);
            window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            context.Window.ClearFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);

            // Regarding tab indicator color in Android, it can be changed only from 'tabIndicatorColor' located in color.xml (inside Resources folder)
            // There is no way to change it automatically from 'BarIndicatorColor' property like on iOS

            tablayout.SetPadding(0, (GetStatusBarHeight() * 2), 0, 0);
            tablayout.Elevation = 8f;
        }
        
        int GetStatusBarHeight()
        {
            int statusBarHeight = -1;
            int resourceId = Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
                statusBarHeight = Resources.GetDimensionPixelSize(resourceId);

            return statusBarHeight;
        }

        void SetGradientOrientation()
        {
            var control = (GradientTabbedPage)this.Element;
            gradient.SetGradientType(GradientType.LinearGradient);

            if (control.Orientation == GradientOrientation.Horizontal)
            {
                gradient.SetOrientation(GradientDrawable.Orientation.LeftRight);
                gradient.SetColors(new int[] { control.StartColor.ToAndroid(), control.EndColor.ToAndroid() });
            }
            else if (control.Orientation == GradientOrientation.Vertical)
            {
                gradient.SetOrientation(GradientDrawable.Orientation.TopBottom);
                gradient.SetColors(new int[] { control.StartColor.ToAndroid(), control.EndColor.ToAndroid() });
            }
            else if (control.Orientation == GradientOrientation.BlTr)
            {
                gradient.SetOrientation(GradientDrawable.Orientation.BlTr);
                gradient.SetColors(new int[] { control.StartColor.ToAndroid(), control.EndColor.ToAndroid() });
            }
            else if (control.Orientation == GradientOrientation.BrTl)
            {
                gradient.SetOrientation(GradientDrawable.Orientation.BlTr);
                gradient.SetColors(new int[] { control.StartColor.ToAndroid(), control.EndColor.ToAndroid() });
            }
            else if (control.Orientation == GradientOrientation.TlBr)
            {
                gradient.SetOrientation(GradientDrawable.Orientation.TlBr);
                gradient.SetColors(new int[] { control.StartColor.ToAndroid(), control.EndColor.ToAndroid() });
            }
            else if (control.Orientation == GradientOrientation.TrBl)
            {
                gradient.SetOrientation(GradientDrawable.Orientation.TrBl);
                gradient.SetColors(new int[] { control.StartColor.ToAndroid(), control.EndColor.ToAndroid() });
            }
        }
    }
}
