using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YmrtLibrary.AxisChart
{
    public abstract class Axis : UserControl
    {
        protected Canvas root;

        public Axis()
        {
            root = new Canvas();
            Content = root;

            SizeChanged += (s, e) => (s as Axis)?.Refresh();


        }



        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(Axis), new PropertyMetadata(100d, OnRangeChange));



        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(Axis), new PropertyMetadata(0d, OnRangeChange));





        public double Step
        {
            get { return (double)GetValue(StepProperty); }
            set { SetValue(StepProperty, value); }
        }

        public static readonly DependencyProperty StepProperty =
            DependencyProperty.Register("Step", typeof(double), typeof(Axis), new PropertyMetadata(10d, OnRangeChange));

        protected static void OnRangeChange(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as Ticks)?.Refresh();

        protected abstract void Refresh();
        protected abstract double EqualRatio(double value);
        protected virtual bool IsRender() => RenderSize.Width <= 0 || (Maximum - Minimum) == 0;
    }
    }
