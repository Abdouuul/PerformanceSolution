namespace Performance.Lib;

public interface IPerformanceService
{
    double GetPerformance(Tuple<DateTime, double>[] dataset, DateTime fromDate, DateTime todate);
}
