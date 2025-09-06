using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownianMotionApp.Services.Interfaces {
    public interface IBrownianMotionService {
        double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays);
    }
}
