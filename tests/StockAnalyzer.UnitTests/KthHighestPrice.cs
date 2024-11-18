namespace StockAnalyzer.UnitTests;

public class StockAnalyzerQ3Tests
{
    // Unit tests for Q3: Kth Highest Stock Price
    [Fact]
    public void FindKthHighestPrice_ShouldReturnCorrectValue()
    {
        // Arrange
        int[] prices = [3, 2, 1, 5, 6, 4];
        const int k = 2;

        // Act
        var result = KthHighestPriceCalculator.KthHighestPrice(prices, k);

        // Assert
        Assert.Equal(5, result); // 5 is the 2nd highest value
    }

    [Fact]
    public void FindKthHighestPrice_ShouldThrowException_WhenKIsInvalid()
    {
        // Arrange
        int[] prices = [3, 2, 1, 5, 6, 4];
        const int k = 7; // k is greater than array length

        // Act & Assert
        Assert.Throws<ArgumentException>(() => KthHighestPriceCalculator.KthHighestPrice(prices, k));
    }
}
