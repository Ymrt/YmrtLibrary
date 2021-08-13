using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace YmrtLibrary.AxisChart
{
    public abstract class IntervalTicks:Ticks
    {


        public double MinorTickLength
        {
            get { return (double)GetValue(MinorTickLengthProperty); }
            set { SetValue(MinorTickLengthProperty, value); }
        }

        public static readonly DependencyProperty MinorTickLengthProperty =
            DependencyProperty.Register("MinorTickLength", typeof(double), typeof(IntervalTicks), new PropertyMetadata(3d,OnRangeChange));



        public bool IsShowFirst
        {
            get { return (bool)GetValue(IsShowFirstProperty); }
            set { SetValue(IsShowFirstProperty, value); }
        }

        public static readonly DependencyProperty IsShowFirstProperty =
            DependencyProperty.Register("IsShowFirst", typeof(bool), typeof(IntervalTicks), new PropertyMetadata(false,OnRangeChange));



        public bool IsShowEnd
        {
            get { return (bool)GetValue(IsShowEndProperty); }
            set { SetValue(IsShowEndProperty, value); }
        }

        public static readonly DependencyProperty IsShowEndProperty =
            DependencyProperty.Register("IsShowEnd", typeof(bool), typeof(IntervalTicks), new PropertyMetadata(false,OnRangeChange));



        public int Interval
        {
            get { return (int)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register("Interval", typeof(int), typeof(IntervalTicks), new PropertyMetadata(1,OnRangeChange));


        protected override bool IsRender() => base.IsRender() || Step == 0;
    }
}
