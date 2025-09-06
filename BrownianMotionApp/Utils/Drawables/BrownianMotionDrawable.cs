using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Utils.Drawables {
    public class BrownianMotionDrawable : IDrawable {
        public double[]? Prices { get; set; }

        public void Draw(ICanvas canvas, RectF dirtyRect) {
            if (Prices == null || Prices.Length < 2)
                return;

            float width = dirtyRect.Width;
            float height = dirtyRect.Height;

            double min = double.MaxValue;
            double max = double.MinValue;
            foreach (var p in Prices) {
                if (p < min) min = p;
                if (p > max) max = p;
            }

            float marginLeft = 50;
            float marginBottom = 40;
            float chartWidth = width - marginLeft - 10;
            float chartHeight = height - marginBottom - 10;

            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 1;

            canvas.DrawLine(marginLeft, 10, marginLeft, height - marginBottom);
            canvas.DrawLine(marginLeft, height - marginBottom, width - 10, height - marginBottom);

            float stepX = chartWidth / (Prices.Length - 1);

            var path = new PathF();
            for (int i = 0; i < Prices.Length; i++) {
                float x = marginLeft + i * stepX;
                float y = (float)(height - marginBottom - ((Prices[i] - min) / (max - min)) * chartHeight);

                if (i == 0) path.MoveTo(x, y);
                else path.LineTo(x, y);
            }

            canvas.StrokeColor = Colors.MediumPurple;
            canvas.StrokeSize = 2;
            canvas.DrawPath(path);

            canvas.FontColor = Colors.White;
            canvas.FontSize = 12;

            string minLabel = ((int)Math.Round(min)).ToString();
            string midLabel = ((int)Math.Round((min + max) / 2)).ToString();
            string maxLabel = ((int)Math.Round(max)).ToString();

            canvas.DrawString(maxLabel, 0, 10, marginLeft - 5, 20,
                HorizontalAlignment.Right, VerticalAlignment.Top);
            canvas.DrawString(midLabel, 0, height / 2 - 10, marginLeft - 5, 20,
                HorizontalAlignment.Right, VerticalAlignment.Center);
            canvas.DrawString(minLabel, 0, height - marginBottom - 20, marginLeft - 5, 20,
                HorizontalAlignment.Right, VerticalAlignment.Bottom);

            int lastDay = Prices.Length - 1;
            canvas.DrawString("0", marginLeft, height - marginBottom + 5, 20, 20,
                HorizontalAlignment.Center, VerticalAlignment.Top);
            canvas.DrawString((lastDay / 2).ToString(), marginLeft + chartWidth / 2, height - marginBottom + 5, 40, 20,
                HorizontalAlignment.Center, VerticalAlignment.Top);
            canvas.DrawString(lastDay.ToString(), marginLeft + chartWidth, height - marginBottom + 5, 40, 20,
                HorizontalAlignment.Center, VerticalAlignment.Top);
        }
    }
}
