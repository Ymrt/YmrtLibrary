using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows;

namespace YmrtLibrary.AxisChart
{
    public class IntervalYTicks:IntervalTicks
    {
        protected override double EqualRatio(double value) => RenderSize.Height - (value - Minimum) / (Maximum - Minimum) * RenderSize.Height;
        protected override void Refresh()
        {
            root.Children.Clear();
            if (IsRender()) return;
            double v = Minimum;
            double y;
            int i = 0;
            do
            {
                y = EqualRatio(v);
                root.Children.Add(
                        new Line
                        {
                            X1 = 0,
                            X2 = i%(Interval+1)==0?TickLength:MinorTickLength,
                            Y1 = y,
                            Y2 = y,
                            Stroke = Stroke,
                            StrokeThickness = StrokeTickness
                        }
                    );
                v += Step;
                i++;
            } while (v <= Maximum);
            if (!IsShowEnd) root.Children[root.Children.Count-1].Visibility = Visibility.Collapsed;
            if (!IsShowFirst) root.Children[0].Visibility = Visibility.Collapsed;
        }
    }
}
