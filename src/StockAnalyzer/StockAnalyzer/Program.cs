namespace StockAnalyzer;

internal static class Program
{
    static void Main(string[] args)
    {
        int[] prices = [7, 1, 5, 3, 6, 4];

        var maxProfit = MaxProfitCalculator.MaxProfit(prices);
        Console.WriteLine($"Max Profit: {maxProfit}");  // Output: Max Profit: 5

        const int k = 2;
        var kthHighestPrice = KthHighestPriceCalculator.KthHighestPrice(prices, k);
        Console.WriteLine($"{k}th Highest Price: {kthHighestPrice}");  // Output: 2th Highest Price: 6

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}