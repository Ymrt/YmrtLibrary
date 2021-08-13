using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace YmrtLibrary.AxisChart
{
    public class YTicks:Ticks
    {
        protected override double EqualRatio(double value) => RenderSize.Height - (value - Minimum) / (Maximum - Minimum) * RenderSize.Height;
        protected override void Refresh()
        {
            root.Children.Clear();
            if (IsRender()) return;
            double v = Minimum;
            double y;

            do
            {
                y = EqualRatio(v);
                root.Children.Add(
                        new Line
                        {
                            X1 = 0,
                            X2 = TickLength,
                            Y1 = y,
                            Y2 = y,
                            Stroke = Stroke,
                            StrokeThickness = StrokeTickness
                        }
                    );
                v += Step;
            } while (v <= Maximum);
        }
    }
}

