using BrownianMotionApp.Services.Interfaces;

/// <summary>
/// Serviço responsável por gerar simulações de Movimento Browniano geométrico.
/// </summary>
public class BrownianMotionService : IBrownianMotionService {
    private readonly Random _rand;

    /// <summary>
    /// Construtor que permite injetar uma instância de Random com seed para testes ou reprodutibilidade.
    /// </summary>
    public BrownianMotionService(Random? rand = null) {
        _rand = rand ?? new Random();
    }

    /// <summary>
    /// Gera uma série de preços simulados com base em parâmetros estatísticos.
    /// </summary>
    /// <param name="sigma">Volatilidade do ativo.</param>
    /// <param name="mean">Retorno médio esperado.</param>
    /// <param name="initialPrice">Preço inicial da simulação.</param>
    /// <param name="numSteps">Número de passos a serem simulados.</param>
    /// <returns>Array com os preços simulados ao longo do período.</returns>
    public double[] GenerateBrownianMotion(double sigma, double mean, double initialPrice, int numSteps) {
        double[] prices = new double[numSteps];
        prices[0] = initialPrice;
        for (int i = 1; i < numSteps; i++) {
            double u1 = 1.0 - _rand.NextDouble();
            double u2 = 1.0 - _rand.NextDouble();
            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);
            double dailyReturn = mean + sigma * z;
            prices[i] = prices[i - 1] * Math.Exp(dailyReturn);
        }
        return prices;
    }
}
