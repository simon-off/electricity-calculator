namespace ElectricityTesting;
using static ElectricityCalculator.Data.Calculator;

public class CalculatorTest
{
    [Fact]
    public void AddTest()
    {
        // Arrange
        int expected = 10;

        // Act
        int result = Add(5, 5);

        // Assert
        Assert.Equal(expected, result);
    }
}
