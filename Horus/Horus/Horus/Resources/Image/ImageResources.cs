using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Horus.Resources.Image
{
    [ContentProperty(nameof(Source))]
    public class ImageResources : IMarkupExtension
    {
        /// <summary>
        /// Get or Set the name of the image to object to 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// When implemented in a derived class, returns an object that is supplied as the value of the target property for this markup extension.
        /// </summary>
        /// <param name="serviceProvider">Service provider helper who can provide services for the dialup extension</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 20.Jan.2023
        /// </reference>
        /// <returns>El valor del objeto que se establecerá en la propiedad donde se aplica la extensión</returns>
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
                return null;
            Source = $"Horus.Resources.Image.{Source}";
            return ImageSource.FromResource(Source, typeof(ImageResources).GetTypeInfo().Assembly);
        }
    }
}

