using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Models {
    public class LineDataDTO {
        public double[] Prices { get; set; }
        public Color Color { get; set; }
        public string Name { get; set; }

        public LineDataDTO(double[] prices, Color color, string name = "") {
            Prices = prices;
            Color = color;
            Name = name;
        }
    }
}
