using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Horus.Helpers.CustomControls
{
    /// <summary>
    /// Class that allows the Entry control to be extended to customize some properties and characteristics
    /// </summary>
    /// <reference>
    /// Autor: Carlos.Orjuela | 20.Jan.2023
    /// </reference>
    public class CustomEntry : Entry
    {
        /// <summary>
        /// Attribute that allows parameterizing the outline of the corners of the text controls
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public static BindableProperty CornerRadiusProperty =
           BindableProperty.Create(nameof(CornerRadius),
                                   typeof(int),
                                   typeof(CustomEntry),
                                   0);

        /// <summary>
        /// Attribute that allows parameterizing the thickness of the border of the text control
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public static BindableProperty BorderThicknessProperty =
            BindableProperty.Create(nameof(BorderThickness),
                                    typeof(int),
                                    typeof(CustomEntry),
                                    0);

        /// <summary>
        /// Attribute that allows parameterizing the padding of the text control with respect to the parent container
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public static BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding),
                                    typeof(Thickness),
                                    typeof(CustomEntry),
                                    new Thickness(5));

        /// <summary>
        /// Attribute that allows parameterizing the color of the border of the text control
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public static BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor),
                                    typeof(Color),
                                    typeof(CustomEntry),
                                    Color.Transparent);

        /// <summary>
        /// property that defines the outline of the corners of the control
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public int CornerRadius
        {
            get => (int)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        /// <summary>
        /// property that defines the thickness of the control's border
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public int BorderThickness
        {
            get => (int)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        /// <summary>
        /// property that defines the color of the border of the control
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        /// <summary>
        /// This property cannot be changed at runtime in iOS.
        /// </summary>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        public Thickness Padding
        {
            get => (Thickness)GetValue(PaddingProperty);
            set => SetValue(PaddingProperty, value);
        }

    }
}

