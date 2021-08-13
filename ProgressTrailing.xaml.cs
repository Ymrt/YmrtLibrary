using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace YmrtLibrary
{
    public class RadiusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value * 2;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    /// <summary>
    /// ProgressTrailing.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressTrailing : Border
    {
        private double oldValue ;
        public ProgressTrailing()
        {
            InitializeComponent();
            DataContext = this;
            oldValue = Value;
            SizeChanged += (s, e) => OnValue();
        }
        public double SymbolRadius
        {
            get { return (double)GetValue(SymbolRadiusProperty); }
            set { SetValue(SymbolRadiusProperty, value); }
        }

        public static readonly DependencyProperty SymbolRadiusProperty =
            DependencyProperty.Register("SymbolRadius", typeof(double), typeof(ProgressTrailing), new PropertyMetadata(10d, (d, e) => (d as ProgressTrailing)?.SetSymbolMargin()));



        public Thickness SymbolBorderThickness
        {
            get { return (Thickness)GetValue(SymbolBorderThicknessProperty); }
            set { SetValue(SymbolBorderThicknessProperty, value); }
        }

        public static readonly DependencyProperty SymbolBorderThicknessProperty =
            DependencyProperty.Register("SymbolBorderThickness", typeof(Thickness), typeof(ProgressTrailing), new PropertyMetadata(new Thickness(2)));




        public Brush SymbolBorderColor
        {
            get { return (Brush)GetValue(SymbolBorderColorProperty); }
            set { SetValue(SymbolBorderColorProperty, value); }
        }

        public static readonly DependencyProperty SymbolBorderColorProperty =
            DependencyProperty.Register("SymbolBorderColor", typeof(Brush), typeof(ProgressTrailing), new PropertyMetadata(Brushes.LightGray));




        public Brush SymbolColor
        {
            get { return (Brush)GetValue(SymbolColorProperty); }
            set { SetValue(SymbolColorProperty, value); }
        }

        public static readonly DependencyProperty SymbolColorProperty =
            DependencyProperty.Register("SymbolColor", typeof(Brush), typeof(ProgressTrailing), new PropertyMetadata(Brushes.LightGoldenrodYellow));



        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(double), typeof(ProgressTrailing), new PropertyMetadata(0d, (d, e) => (d as ProgressTrailing)?.OnValue()));




        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }

        public static readonly DependencyProperty MaximumProperty =
            DependencyProperty.Register("Maximum", typeof(double), typeof(ProgressTrailing), new PropertyMetadata(100d, (d, e) => (d as ProgressTrailing)?.OnValue()));



        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }

        public static readonly DependencyProperty MinimumProperty =
            DependencyProperty.Register("Minimum", typeof(double), typeof(ProgressTrailing), new PropertyMetadata(0d, (d, e) => (d as ProgressTrailing)?.OnValue()));




        public double InnerWidth
        {
            get { return (double)GetValue(InnerWidthProperty); }
            set { SetValue(InnerWidthProperty, value); }
        }

        public static readonly DependencyProperty InnerWidthProperty =
            DependencyProperty.Register("InnerWidth", typeof(double), typeof(ProgressTrailing), new PropertyMetadata(10d));




        public CornerRadius SymbolBorderRadius
        {
            get { return (CornerRadius)GetValue(SymbolBorderRadiusProperty); }
            set { SetValue(SymbolBorderRadiusProperty, value); }
        }

        public static readonly DependencyProperty SymbolBorderRadiusProperty =
            DependencyProperty.Register("SymbolBorderRadius", typeof(CornerRadius), typeof(ProgressTrailing), new PropertyMetadata(new CornerRadius(10)));




        public Brush ValueColor
        {
            get { return (Brush)GetValue(ValueColorProperty); }
            set { SetValue(ValueColorProperty, value); }
        }

        public static readonly DependencyProperty ValueColorProperty =
            DependencyProperty.Register("ValueColor", typeof(Brush), typeof(ProgressTrailing), new PropertyMetadata(Brushes.AliceBlue));


        private void SetSymbolMargin()
        {
            try
            {
                _Symbol.Margin = new Thickness(-SymbolRadius);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void OnValue()
        {
            try
            {
                if (Value > Maximum) Value = Maximum;
                if (Value < Minimum) Value = Maximum;
                
               var AnimationValue = new DoubleAnimation()
                {
                    From = InnerWidth,
                    To = (Value - Minimum) / (Maximum - Minimum) * this.RenderSize.Width,
                    Duration = new Duration(TimeSpan.FromSeconds(0.2)),
                };
                var AnimationOpacity = new DoubleAnimation()
                {
                    From = 1,
                    To = 0,
                    Duration = new Duration(TimeSpan.FromSeconds(1)),
                };

                this.BeginAnimation(InnerWidthProperty, AnimationValue);
                _Canvas.BeginAnimation(OpacityProperty, AnimationOpacity);
                RotateTransform rotateTransform = new RotateTransform();

                if (Value > oldValue)
                {
                    rotateTransform.Angle = 0;
                    var AnimationMarginToLeft = new ThicknessAnimation()
                    {
                        From = new Thickness(0, -50, 0, -50),
                        To = new Thickness(0, -50,135, -50),

                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                    };
                    _Canvas.BeginAnimation(MarginProperty, AnimationMarginToLeft);

                }

                if (Value < oldValue)
                {
                    rotateTransform.Angle = 180;
                    var AnimationMarginToRight = new ThicknessAnimation()
                    {
                        From = new Thickness(0, -50, 0, -50),
                        To = new Thickness(0, -50, -135, -50),

                        Duration = new Duration(TimeSpan.FromSeconds(1)),
                    };
                    _Canvas.BeginAnimation(MarginProperty, AnimationMarginToRight);
                }

                _Canvas.RenderTransform = rotateTransform;
                oldValue = Value;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
