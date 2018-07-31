using Xamarin.Forms;

namespace SpotifyForms.Core.Views.Controls
{
    /// <summary>
    /// ContentView that allows you to have a Gradient for the background.
    /// </summary>
    public class GradientContentView : ContentView
    {
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create("CornerRadius", typeof(float), typeof(GradientContentView), default(float));


        /// <summary>
        /// Start color of the gradient
        /// Defaults to White
        /// </summary>
        public GradientOrientation Orientation
        {
            get { return (GradientOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }

        /// <summary>
        /// The orientation property
        /// </summary>
        public static readonly BindableProperty OrientationProperty =
            BindableProperty.Create("Orientation", typeof(GradientOrientation), typeof(GradientContentView), GradientOrientation.Vertical);

        /// <summary>
        /// Start color of the gradient
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
            BindableProperty.Create("StartColor", typeof(Color), typeof(GradientContentView), Color.White);

        /// <summary>
        /// End color of the gradient
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
            BindableProperty.Create("EndColor", typeof(Color), typeof(GradientContentView), Color.White);
    }

    /// <summary>
    /// Enum GradientOrientation
    /// </summary>
    public enum GradientOrientation
    {
        /// <summary>
        /// The vertical (Top to Bottom)
        /// </summary>
        Vertical,
        /// <summary>
        /// The horizontal (Left to Right)
        /// </summary>
        Horizontal,
        /// <summary>
        /// The Bottom right to Top left
        /// </summary>
        BrTl,
        /// <summary>
        /// The Bottom left to Top right
        /// </summary>
        BlTr,
        /// <summary>
        /// The Top left to Bottom right
        /// </summary>
        TlBr,
        /// <summary>
        /// The Top right to Bottom left
        /// </summary>
        TrBl
    }
}