using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
namespace YmrtLibrary.AxisChart
{
    public class XTicks:Ticks
    {
        protected override double EqualRatio(double value) => (value - Minimum) / (Maximum - Minimum) * RenderSize.Width;
        protected override void Refresh()
        {
            root.Children.Clear();
            if (IsRender()) return;
            double v = Minimum;
            double x;

            do
            {
                x = EqualRatio(v);
                root.Children.Add(
                        new Line
                        {
                            X1 = x,
                            X2 = x,
                            Y1 = 0,
                            Y2 = TickLength,
                            Stroke = Stroke,
                            StrokeThickness = StrokeTickness
                        }
                    );
                v += Step;
            } while (v <= Maximum);
        }
    }
}
