using Xamarin.Forms;

namespace SpotifyForms.Core.Views.Controls
{
    public class GradientTabbedPage : TabbedPage
    {
        /// <summary>
        /// Orientation of the gradient.
        /// Defaults to Vertical
        /// </summary>
        public GradientOrientation Orientation
        {
            get { return (GradientOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// Orientation of the gradient
        /// Defaults to Vertical
        /// </summary>
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create("Orientation", typeof(GradientOrientation), typeof(GradientTabbedPage), GradientOrientation.Vertical);

        /// <summary>
        /// Start color of the gradient.
        /// Defaults to White
        /// </summary>
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        /// <summary>
        /// Using a BindableProperty as the backing store for StartColor.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly BindableProperty StartColorProperty =
            BindableProperty.Create("StartColor", typeof(Color), typeof(GradientTabbedPage), Color.White);

        /// <summary>
        /// End color of the gradient.
        /// Defaults to Black
        /// </summary>
        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }

        /// <summary>
        /// Using a BindableProperty as the backing store for EndColor.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly BindableProperty EndColorProperty =
            BindableProperty.Create("EndColor", typeof(Color), typeof(GradientTabbedPage), Color.White);


        /// <summary>
        /// Indicator color for the selected tab.
        /// Defaults to White
        /// </summary>
        public Color BarIndicatorColor
        {
            get { return (Color)GetValue(BarIndicatorColorProperty); }
            set { SetValue(BarIndicatorColorProperty, value); }
        }

        /// <summary>
        /// Using a BindableProperty as the backing store for TabColorIndicator.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly BindableProperty BarIndicatorColorProperty =
            BindableProperty.Create("BarIndicatorColor", typeof(Color), typeof(GradientTabbedPage), Color.White);


    }
}


