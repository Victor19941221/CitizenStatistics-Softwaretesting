using System.Collections.Generic;
using CitizenStatistics.Models;
using CitizenStatistics.Services;
using Xunit;

namespace CitizenStatisticsTest;

public class StatisticsServiceTest
{
    [Fact]
    public void AverageAge_ReturnsCorrectAverage()
    {
        // Arrangeee
        var citizens = new List<Citizen>
        {
            new Citizen { Age = 25 },
            new Citizen { Age = 35 },
            new Citizen { Age = 45 }
        };
        var service = new StatisticsService(citizens);

        // Act
        var averageAge = service.AverageAge();

        // Assert
        Assert.Equal(35, averageAge);
    }

    [Fact]
    public void MedianAge_ReturnsCorrectMedian_ForOddCount()
    {
        // Arrange
        var citizens = new List<Citizen>
        {
            new Citizen { Age = 20 },
            new Citizen { Age = 30 },
            new Citizen { Age = 40 }
        };
        var service = new StatisticsService(citizens);

        // Act
        var medianAge = service.MedianAge();

        // Assert
        Assert.Equal(30, medianAge);
    }

    [Fact]
    public void MedianAge_ReturnsCorrectMedian_ForEvenCount()
    {
        // Arrange
        var citizens = new List<Citizen>
        {
            new Citizen { Age = 20 },
            new Citizen { Age = 30 },
            new Citizen { Age = 40 },
            new Citizen { Age = 50 }
        };
        var service = new StatisticsService(citizens);

        // Act
        var medianAge = service.MedianAge();

        // Assert
        Assert.Equal(35, medianAge);
    }

    [Fact]
    public void HighestIncome_ReturnsCorrectValue()
    {
        // Arrange
        var citizens = new List<Citizen>
        {
            new Citizen { Income = 50000 },
            new Citizen { Income = 75000 },
            new Citizen { Income = 60000 }
        };
        var service = new StatisticsService(citizens);

        // Act
        var highestIncome = service.HighestIncome();

        // Assert
        Assert.Equal(75000, highestIncome);
    }

    [Fact]
    public void LowestIncome_ReturnsCorrectValue()
    {
        // Arrange
        var citizens = new List<Citizen>
        {
            new Citizen { Income = 50000 },
            new Citizen { Income = 75000 },
            new Citizen { Income = 60000 }
        };
        var service = new StatisticsService(citizens);

        // Act
        var lowestIncome = service.LowestIncome();

        // Assert
        Assert.Equal(50000, lowestIncome);
    }

    [Fact]
    public void TopPayingProfessions_ReturnsCorrectProfessions()
    {
        // Arrange
        var citizens = new List<Citizen>
        {
            new Citizen { Profession = "Engineer", Income = 80000 },
            new Citizen { Profession = "Doctor", Income = 150000 },
            new Citizen { Profession = "Teacher", Income = 50000 },
            new Citizen { Profession = "Engineer", Income = 90000 },
            new Citizen { Profession = "Doctor", Income = 140000 },
            new Citizen { Profession = "Artist", Income = 40000 }
        };
        var service = new StatisticsService(citizens);

        // Act
        var topProfessions = service.TopPayingProfessions(2);

        // Assert
        Assert.Equal(new[] { "Doctor", "Engineer" }, topProfessions);
    }

    [Fact]
    public void Methods_ReturnZero_WhenNoCitizens()
    {
        // Arrange
        var citizens = new List<Citizen>();
        var service = new StatisticsService(citizens);

        // Act & Assert
        Assert.Equal(0, service.AverageAge());
        Assert.Equal(0, service.MedianAge());
        Assert.Equal(0, service.HighestIncome());
        Assert.Equal(0, service.LowestIncome());
        Assert.Empty(service.TopPayingProfessions(3));
    }
}
