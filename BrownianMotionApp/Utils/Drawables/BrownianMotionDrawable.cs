using BrownianMotionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Utils.Drawables {
    public class BrownianMotionDrawable : IDrawable {
        public List<LineData> Lines { get; set; } = new List<LineData>();

        private const float MARGIN_LEFT = 80;
        private const float MARGIN_BOTTOM = 60;
        private const float MARGIN_TOP = 20;
        private const float MARGIN_RIGHT = 20;

        public void Draw(ICanvas canvas, RectF dirtyRect) {
            if (Lines == null || !Lines.Any() || Lines.All(l => l.Prices == null || l.Prices.Length < 2))
                return;

            float width = dirtyRect.Width;
            float height = dirtyRect.Height;

            float chartWidth = width - MARGIN_LEFT - MARGIN_RIGHT;
            float chartHeight = height - MARGIN_BOTTOM - MARGIN_TOP;

            var (globalMin, globalMax) = GetGlobalMinMax();

            DrawAxes(canvas, width, height);
            DrawAxisLabels(canvas, width, height);
            DrawScaleLabels(canvas, height, globalMin, globalMax);
            DrawDayLabels(canvas, width, height);
            DrawLines(canvas, chartWidth, chartHeight, globalMin, globalMax);
        }

        private (double min, double max) GetGlobalMinMax() {
            double globalMin = double.MaxValue;
            double globalMax = double.MinValue;

            foreach (var line in Lines) {
                if (line.Prices == null) continue;

                foreach (var price in line.Prices) {
                    if (price < globalMin) globalMin = price;
                    if (price > globalMax) globalMax = price;
                }
            }

            return (globalMin, globalMax);
        }

        private void DrawAxes(ICanvas canvas, float width, float height) {
            canvas.StrokeColor = Colors.White;
            canvas.StrokeSize = 1;

            canvas.DrawLine(MARGIN_LEFT, MARGIN_TOP, MARGIN_LEFT, height - MARGIN_BOTTOM);
            canvas.DrawLine(MARGIN_LEFT, height - MARGIN_BOTTOM, width - MARGIN_RIGHT, height - MARGIN_BOTTOM);
        }

        private void DrawAxisLabels(ICanvas canvas, float width, float height) {
            float chartHeight = height - MARGIN_TOP - MARGIN_BOTTOM;
            float chartWidth = width - MARGIN_LEFT - MARGIN_RIGHT;

            canvas.FontColor = Colors.White;
            canvas.FontSize = 14;

            canvas.DrawString("Dias", MARGIN_LEFT + chartWidth / 2, MARGIN_TOP + chartHeight + 20, 50, 20,
                HorizontalAlignment.Left, VerticalAlignment.Top);
        }

        private void DrawScaleLabels(ICanvas canvas, float height, double globalMin, double globalMax) {
            float chartHeight = height - MARGIN_TOP - MARGIN_BOTTOM;

            canvas.FontColor = Colors.White;
            canvas.FontSize = 12;

            string minLabel = ((int)Math.Round(globalMin)).ToString("C");
            string midLabel = ((int)Math.Round((globalMin + globalMax) / 2)).ToString("C");
            string maxLabel = ((int)Math.Round(globalMax)).ToString("C");

            // Y-axis scale labels (inside the margins)
            canvas.DrawString(maxLabel, 0, MARGIN_TOP - 6, MARGIN_LEFT - 5, 20,
                HorizontalAlignment.Right, VerticalAlignment.Bottom);
            canvas.DrawString(midLabel, 0, MARGIN_TOP + chartHeight / 2 - 6, MARGIN_LEFT - 5, 20,
                HorizontalAlignment.Right, VerticalAlignment.Center);
            canvas.DrawString(minLabel, 0, MARGIN_TOP + chartHeight - 6, MARGIN_LEFT - 5, 20,
                HorizontalAlignment.Right, VerticalAlignment.Top);
        }

        private void DrawDayLabels(ICanvas canvas, float width, float height) {
            if (!Lines.Any()) return;

            int maxDays = Lines.Max(l => l.Prices?.Length ?? 0);
            if (maxDays <= 1) return;

            float chartWidth = width - MARGIN_LEFT - MARGIN_RIGHT;
            float chartHeight = height - MARGIN_TOP - MARGIN_BOTTOM;

            canvas.FontColor = Colors.White;
            canvas.FontSize = 12;

            canvas.DrawString("0", MARGIN_LEFT, MARGIN_TOP + chartHeight + 5, 20, 20,
                HorizontalAlignment.Left, VerticalAlignment.Top);
            canvas.DrawString((maxDays / 2).ToString(), MARGIN_LEFT + chartWidth / 2, MARGIN_TOP + chartHeight + 5, 40, 20,
                HorizontalAlignment.Left, VerticalAlignment.Top);
            canvas.DrawString(maxDays.ToString(), MARGIN_LEFT + chartWidth, MARGIN_TOP + chartHeight + 5, 40, 20,
                HorizontalAlignment.Left, VerticalAlignment.Top);
        }

        private void DrawLines(ICanvas canvas, float chartWidth, float chartHeight, double globalMin, double globalMax) {
            foreach (var line in Lines) {
                if (line.Prices == null || line.Prices.Length < 2) continue;

                DrawSingleLine(canvas, line, chartWidth, chartHeight, globalMin, globalMax);
            }
        }

        private void DrawSingleLine(ICanvas canvas, LineData line, float chartWidth, float chartHeight, double globalMin, double globalMax) {
            float stepX = chartWidth / (line.Prices.Length - 1);
            var path = new PathF();

            for (int i = 0; i < line.Prices.Length; i++) {
                float x = MARGIN_LEFT + i * stepX;
                float y = MARGIN_TOP + chartHeight - (float)((line.Prices[i] - globalMin) / (globalMax - globalMin) * chartHeight);

                if (i == 0)
                    path.MoveTo(x, y);
                else
                    path.LineTo(x, y);
            }

            canvas.StrokeColor = line.Color;
            canvas.StrokeSize = 2;
            canvas.DrawPath(path);
        }
    }
}
