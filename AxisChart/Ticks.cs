using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace YmrtLibrary.AxisChart
{
    public abstract class Ticks : Axis
    {
        public Ticks()
        {

        }

        public Brush Stroke
        {
            get { return (Brush)GetValue(StrokeProperty); }
            set { SetValue(StrokeProperty, value); }
        }

        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(Brush), typeof(Ticks), new PropertyMetadata(Brushes.Lime, OnRangeChange));



        public double TickLength
        {
            get { return (double)GetValue(TickLengthProperty); }
            set { SetValue(TickLengthProperty, value); }
        }

        public static readonly DependencyProperty TickLengthProperty =
            DependencyProperty.Register("TickLength", typeof(double), typeof(Ticks), new PropertyMetadata(5d, OnRangeChange));




        public double StrokeTickness
        {
            get { return (double)GetValue(StrokeTicknessProperty); }
            set { SetValue(StrokeTicknessProperty, value); }
        }

        public static readonly DependencyProperty StrokeTicknessProperty =
            DependencyProperty.Register("StrokeTickness", typeof(double), typeof(Ticks), new PropertyMetadata(1d, OnRangeChange));


        protected override bool IsRender() => base.IsRender() || Step == 0;
    }
}
