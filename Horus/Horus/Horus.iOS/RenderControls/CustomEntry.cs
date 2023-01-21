using UIKit;
using System;
using Foundation;
using CoreGraphics;
using Xamarin.Forms;
using System.Drawing;
using System.ComponentModel;
using Horus.iOS.RenderControls;
using Xamarin.Forms.Platform.iOS;
using Horus.Helpers.CustomControls;

[assembly: ExportRenderer(typeof(Horus.Helpers.CustomControls.CustomEntry), typeof(Horus.iOS.RenderControls.CustomEntry))]
namespace Horus.iOS.RenderControls
{
    public class CustomEntry : EntryRenderer
    {
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
            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}

