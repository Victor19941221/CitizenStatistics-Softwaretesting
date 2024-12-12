namespace CitizenStatistics.Models;

public class Statistics
{
    public int AverageAge { get; set; }
    public int MedianAge { get; set; }
    public int HighestIncome { get; set; }
    public int LowestIncome { get; set; }
    public string[] TopPayingProfessions { get; set; }
    
}