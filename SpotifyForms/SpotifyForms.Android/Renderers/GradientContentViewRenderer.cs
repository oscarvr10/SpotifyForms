﻿using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using SpotifyForms.Core.Views.Controls;
using SpotifyForms.Droid.Renderers;
using Android.Content;

[assembly: ExportRenderer(typeof(GradientContentView), typeof(GradientContentViewRenderer))]
namespace SpotifyForms.Droid.Renderers
{
    public class GradientContentViewRenderer : ViewRenderer<GradientContentView, Android.Views.View>
    {
        public GradientContentViewRenderer(Context context): base(context)
        {

        }
        public GradientDrawable GradientDrawable { get; set; }
        /// <summary>
        /// Gets the underlying element typed as an <see cref="GradientContentView"/>.
        /// </summary>
        private GradientContentView GradientContentView
        {
            get { return (GradientContentView)Element; }
        }

        /// <summary>
        /// Setup the gradient layer
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<GradientContentView> e)
        {
            base.OnElementChanged(e);

            if (GradientContentView != null)
            {
                GradientDrawable = new GradientDrawable();
                GradientDrawable.SetColors(new int[] { GradientContentView.StartColor.ToAndroid(), GradientContentView.EndColor.ToAndroid() });
                GradientDrawable.SetCornerRadius(GradientContentView.CornerRadius);
            }
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (GradientDrawable != null && GradientContentView != null)
            {
                if (e.PropertyName == GradientContentView.StartColorProperty.PropertyName ||
                    e.PropertyName == GradientContentView.EndColorProperty.PropertyName)
                {
                    GradientDrawable.SetColors(new int[] { GradientContentView.StartColor.ToAndroid(), GradientContentView.EndColor.ToAndroid() });
                    Invalidate();
                }

                if (e.PropertyName == VisualElement.WidthProperty.PropertyName ||
                    e.PropertyName == VisualElement.HeightProperty.PropertyName ||
                    e.PropertyName == GradientContentView.OrientationProperty.PropertyName)
                {
                    Invalidate();
                }
            }
        }

        protected override bool DrawChild(Canvas canvas, global::Android.Views.View child, long drawingTime)
        {
            GradientDrawable.Bounds = canvas.ClipBounds;
            
            switch (GradientContentView.Orientation)
            {
                case GradientOrientation.Vertical:
                    GradientDrawable.SetOrientation(GradientDrawable.Orientation.TopBottom);
                    break;
                case GradientOrientation.Horizontal:
                    GradientDrawable.SetOrientation(GradientDrawable.Orientation.LeftRight);
                    break;
                case GradientOrientation.BrTl:
                    GradientDrawable.SetOrientation(GradientDrawable.Orientation.BrTl);
                    break;
                case GradientOrientation.BlTr:
                    GradientDrawable.SetOrientation(GradientDrawable.Orientation.BlTr);
                    break;
                case GradientOrientation.TlBr:
                    GradientDrawable.SetOrientation(GradientDrawable.Orientation.TlBr);
                    break;
                case GradientOrientation.TrBl:
                    GradientDrawable.SetOrientation(GradientDrawable.Orientation.TrBl);
                    break;
                default:
                    break;
            }
            
            GradientDrawable.Draw(canvas);
            return base.DrawChild(canvas, child, drawingTime);
        }
    }
}