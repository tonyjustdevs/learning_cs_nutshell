using static System.Console;

internal class Program
{
    static void Main(string[] args)
    {
        WriteLine("Hello, Using Ref App!");

        int PlayerHealth = 100;

        var tonys_portfolio = new Portfolio();
        WriteLine($"tp_exposure: {tonys_portfolio.Exposure}");

        for (int i = 0; i < 10; i++)
        {
            TonysRiskMetrics.RecalculateRisk(ref tonys_portfolio, out int added_val);
            WriteLine($"tp_exposure: {tonys_portfolio.Exposure} [{added_val}]");

        }

        //var (es, var, stress) = TonysRiskMetrics.CalcRiskMetricsTuples(in tonys_portfolio);
        //WriteLine("{0},{1},{2}", es, var, stress);
        var metrics = TonysRiskMetrics.CalcRiskMetricsTuples(in tonys_portfolio);
        WriteLine("{0},{1},{2}", metrics.es, metrics.var, metrics.stress);

        // caller:
        // - i understand youre working with my portfolio variable
        // - i give you permission to change it
    }
    static void TakeDamage(ref int PlayerHealth) => PlayerHealth -= 20;
    // [1a] ref param: i need direct acccess to your variable
    // [1a1] dont give me copy,give me actual variable i can modify
    // [1a2]: i might read it, i might modify it

    // [1a] + [1b]: both sides agree



}

class RiskMetrics
{
    public decimal VaR;
    public decimal ES;
    public decimal StressLoss;
}
class TonysRiskMetrics
{
    public static void RecalculateRisk(ref Portfolio portfolio, out int added_val) 
    {
        added_val = (new Random().Next(-1, +2)) * 10;
        portfolio.Exposure += added_val;
    }
    
    public static RiskMetrics CalcRiskMetrics(in Portfolio portfolio)
    {
        var result = new RiskMetrics();
        result.ES = 500;
        result.VaR = 1000;
        result.StressLoss = 690;
        return result;
    }

    public static
    (decimal es, decimal var, decimal stress) CalcRiskMetricsTuples(in Portfolio p)
    {
        return (500, 600, 700);
    }



    public static void CalculateVaR(in Portfolio portfolio) 
    {
        //portfolio.Exposure
    }
}

class Portfolio
{
    List<int> assets = new List<int>();
    decimal _exposure;
    public decimal Exposure { get; set; } = 100;
}