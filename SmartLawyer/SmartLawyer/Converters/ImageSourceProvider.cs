using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace SmartLawyer.Converters
{
    class ImageSourceProvider : MarkupExtension
    {
        public Uri Uri { get; set; }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {

            if (Uri.LocalPath.ToLower().EndsWith(".svg"))
            {
                return new Svg2Xaml.SvgImageExtension()
                {
                    Uri = Uri
                }.ProvideValue(serviceProvider);
            }
            else
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = Uri;
                image.EndInit();
                return image;
            }
        }
    }
}
