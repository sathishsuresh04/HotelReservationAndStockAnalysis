namespace StockAnalyzer.UnitTests;

public class StockAnalyzerQ2Tests
{
    [Fact]
    public void MaxProfit_ShouldReturnMaxProfit()
    {
        // Arrange
        int[] prices = [7, 1, 5, 3, 6, 4];

        // Act
        var result = MaxProfitCalculator.MaxProfit(prices);

        // Assert
        Assert.Equal(5, result); // Buy at 1, sell at 6
    }

    [Fact]
    public void MaxProfit_ShouldReturnZero_WhenPricesAreDecreasing()
    {
        // Arrange
        int[] prices = [7, 6, 4, 3, 1];

        // Act
        var result = MaxProfitCalculator.MaxProfit(prices);

        // Assert
        Assert.Equal(0, result); // No profit can be made
    }
}