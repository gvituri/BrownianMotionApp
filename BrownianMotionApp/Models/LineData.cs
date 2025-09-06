using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Models {
    public class LineData {
        public double[] Prices { get; set; }
        public Color Color { get; set; }

        public LineData(double[] prices, Color color) {
            Prices = prices;
            Color = color;
        }
    }
}
