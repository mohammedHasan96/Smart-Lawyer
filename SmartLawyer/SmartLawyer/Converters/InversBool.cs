﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace SmartLawyer.Converters
{
    class InversBool : MarkupExtension, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !((bool)(value));


        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => !((bool)(value));

        public override object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
