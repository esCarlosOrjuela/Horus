using System;
using Android.Views;
using Xamarin.Forms;
using Android.Content;
using System.ComponentModel;
using Android.Graphics.Drawables;
using Horus.Droid.RenderControls;
using Horus.Helpers.CustomControls;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Horus.Helpers.CustomControls.CustomEntry), typeof(Horus.Droid.RenderControls.CustomEntry))]
namespace Horus.Droid.RenderControls
{
    public class CustomEntry : EntryRenderer
    {
        public CustomEntry(Context context) : base(context) { }

        /// <summary>
        /// We override the OnElementPropertyChanged method, this will allow us to react to the change in the properties in the control.
        /// In this case, whether I change my CornerRadius, BorderThickness, BorderColor, etc , I will always update my Background.
        /// </summary>
        /// <param name="e">Contains event data</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                Control.Background = null;

                var lp = new MarginLayoutParams(Control.LayoutParameters);
                lp.SetMargins(0, 0, 0, 0);
                LayoutParameters = lp;
                Control.LayoutParameters = lp;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }

}

