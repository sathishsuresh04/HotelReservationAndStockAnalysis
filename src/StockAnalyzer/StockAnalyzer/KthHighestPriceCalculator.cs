namespace StockAnalyzer;

using System.Collections.Generic;

public static class KthHighestPriceCalculator
{
    /// <summary>
    /// Calculates the k-th highest stock price in the array.
    /// </summary>
    /// <param name="prices">Array of stock prices.</param>
    /// <param name="k">The k-th position to find.</param>
    /// <returns>k-th highest stock price.</returns>
    public static int KthHighestPrice(int[] prices, int k)
    {
        if (prices == null || prices.Length == 0 || k <= 0 || k > prices.Length)
        {
            throw new ArgumentException("Invalid input");
        }

        // Use a Min-Heap (PriorityQueue) of size k
        var minHeap = new PriorityQueue<int, int>();

        foreach (var t in prices)
        {
            minHeap.Enqueue(t, t);

            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }

        return minHeap.Peek();
    }
}