namespace Performance.Lib;

public class PerformanceService : IPerformanceService
{
    public double GetPerformance(Tuple<DateTime, double>[] dataset, DateTime fromDate, DateTime toDate)
    {
        // Verifying dataset value is not null or length=0
        if (dataset == null || dataset.Length == 0)
        {   
            throw new Exception("Dataset is null or empty");
        }

        // filtering out the tuples we need
        var filteredData = dataset
            .Where(x => x.Item1 >= fromDate && x.Item1 <= toDate)
            .OrderBy(x => x.Item1)
            .ToArray();

        if (filteredData.Length < 2)
            throw new Exception("less than 2 tuples found");

        // We get the date from the first and last tuple in the list filteredData
        double firstValue = filteredData.First().Item2;
        double lastValue = filteredData.Last().Item2;

        if (firstValue == 0)
            throw new DivideByZeroException("Zero division not allowed");

        return (lastValue / firstValue) - 1;
    
    }
}
