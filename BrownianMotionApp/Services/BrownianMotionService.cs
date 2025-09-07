using BrownianMotionApp.Services.Interfaces;

public class BrownianMotionService : IBrownianMotionService {
    private readonly Random _rand;

    public BrownianMotionService(Random? rand = null) {
        _rand = rand ?? new Random();
    }

    public double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numDays) {
        double[] prices = new double[numDays];
        prices[0] = initialPrice;
        for (int i = 1; i < numDays; i++) {
            double u1 = 1.0 - _rand.NextDouble();
            double u2 = 1.0 - _rand.NextDouble();
            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            double dailyReturn = mean + sigma * z;
            prices[i] = prices[i - 1] * Math.Exp(dailyReturn);
        }
        return prices;
    }
}
