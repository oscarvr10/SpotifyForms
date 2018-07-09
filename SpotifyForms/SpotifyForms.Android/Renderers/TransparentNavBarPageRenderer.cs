using Android.Content;
using SpotifyForms.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AView = Android.Views.View;
using Android.Support.V7.Widget;
using Xamarin.Forms.Platform.Android.AppCompat;
using Android.App;
using Android.Views;
using System.Reflection;

[assembly: ExportRenderer(typeof(NavigationPage), typeof(TransparentNavBarPageRenderer))]
namespace SpotifyForms.Droid.Renderers
{
    public class TransparentNavBarPageRenderer : NavigationPageRenderer
    {
        Toolbar _toolbar;
        IPageController PageController => Element as IPageController;
        NavigationPage CustomNavigationPage => Element as NavigationPage;


        public TransparentNavBarPageRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<NavigationPage> e)
        {
            base.OnElementChanged(e);

            var memberInfo = typeof(TransparentNavBarPageRenderer).BaseType;
            if (memberInfo != null)
            {

                var field = memberInfo.GetField(nameof(_toolbar), BindingFlags.Instance | BindingFlags.NonPublic);
                _toolbar = field.GetValue(this) as Toolbar;
                _toolbar.SetBackgroundColor(Color.Transparent.ToAndroid());


                Activity context = Context as Activity;

                var window = context.Window;
                window.AddFlags(WindowManagerFlags.TranslucentStatus);
                context.Window.ClearFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            }
        }


        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            int containerHeight = b - t;

            PageController.ContainerArea = new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));

            for (var i = 0; i < ChildCount; i++)
            {
                AView child = GetChildAt(i);

                if (child is Toolbar)
                    continue;

                child.Layout(0, 0, r, b);
            }
        }
    }
}
