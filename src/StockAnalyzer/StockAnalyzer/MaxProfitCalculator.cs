namespace StockAnalyzer;

public static class MaxProfitCalculator
{
    /// <summary>
    /// Calculates the maximum profit that can be made by buying and selling a stock on the same day.
    /// </summary>
    /// <param name="prices">Array of stock prices.</param>
    /// <returns>Maximum profit.</returns>
    public static int MaxProfit(int[] prices)
    {
        // If there are less than 2 price points, no profit can be made
        if (prices.Length < 2)
            return 0;

        var minPrice = prices[0]; // Initialize minPrice to the first element
        var maxProfit = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            // Update minPrice if the current price is lower than the current minPrice
            if (prices[i] < minPrice)
            {
                minPrice = prices[i];
            }
            else
            {
                // Calculate the profit if the current price is sold at minPrice
                var profit = prices[i] - minPrice;

                // Update maxProfit if the calculated profit is higher
                if (profit > maxProfit)
                {
                    maxProfit = profit;
                }
            }
        }
        return maxProfit;
    }
}