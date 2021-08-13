using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YmrtLibrary.AxisChart
{
    public abstract class Labels : Axis
    {
        public Labels()
        {

        }

        public HorizontalAlignment MyProperty
        {
            get { return (HorizontalAlignment)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(HorizontalAlignment), typeof(Labels), new PropertyMetadata(HorizontalAlignment.Center));

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == ForegroundProperty || e.Property == FontSizeProperty || e.Property == FontFamilyProperty)
                Refresh();

        }
    }

   
}
