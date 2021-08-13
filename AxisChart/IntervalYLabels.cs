using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace YmrtLibrary.AxisChart
{
    public class IntervalYLabels:IntervalLabels
    {
        protected override double EqualRatio(double value) => RenderSize.Height - (value - Minimum) / (Maximum - Minimum) * RenderSize.Height;
        protected override void Refresh()
        {
            root.Children.Clear();
            if (IsRender()) return;
            double v = Minimum;
            double height = RenderSize.Height / ((Maximum - Minimum) / Step) * (Interval + 1);
            double y;
            int i = 0;
            do
            {
                y = EqualRatio(v);
                if (i % (Interval + 1) == 0)
                {
                    var label = new Label
                    {
                        Content = v.ToString(),
                        Height = height,
                        Width = RenderSize.Width,
                        HorizontalContentAlignment = HorizontalAlignment,
                        VerticalContentAlignment = System.Windows.VerticalAlignment.Center,
                        Foreground = Foreground,
                        FontSize = FontSize,
                        FontFamily = FontFamily,
                        Padding = new System.Windows.Thickness(0),
                    };
                root.Children.Add(label);
                    Canvas.SetTop(label, y - height / 2);
                };

                v += Step;
                i++;
            } while (v <= Maximum);
            if (!IsShowEnd) root.Children[root.Children.Count - 1].Visibility = Visibility.Collapsed;
            if (!IsShowFirst) root.Children[0].Visibility = Visibility.Collapsed;
        }
    }
}
