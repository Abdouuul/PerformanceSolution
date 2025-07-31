namespace Performance.Test;
using Performance.Lib;
public class PerformanceServiceTests
{
    public PerformanceService perf_service = new PerformanceService();
        [Fact]
        public void Calculate_performance_test()
        {
            var dataset = new[]
            {
                Tuple.Create(new DateTime(2021, 1, 1), 180.0),
                Tuple.Create(new DateTime(2021, 6, 1), 200.0),
                Tuple.Create(new DateTime(2021, 12, 31), 250.0),
                Tuple.Create(new DateTime(2022, 1, 1), 300.0),
                Tuple.Create(new DateTime(2022, 6, 1), 350.0),
                Tuple.Create(new DateTime(2022, 12, 31), 400.0),
            };

            double result = perf_service.GetPerformance(dataset, new DateTime(2021, 1, 1), new DateTime(2022, 12, 31));
            Assert.Equal(1.2, result, 1); // (400 / 180) -1 = 0.5
        }

        [Fact]
        public void Division_zero_test()
        {
            var dataset = new[]
            {
                Tuple.Create(new DateTime(2022, 12, 3), 0.0),
                Tuple.Create(new DateTime(2022, 12, 31), 150.0),
            };
            Assert.Throws<DivideByZeroException>(() =>
                perf_service.GetPerformance(dataset, new DateTime(2022, 12, 3), new DateTime(2022, 12, 31)));
        }

        [Fact]
        public void Empty_dataset_test()
        {
            var dataset = Array.Empty<Tuple<DateTime, double>>();
            Assert.Throws<Exception>(() =>
                perf_service.GetPerformance(dataset, DateTime.Now.AddDays(-1), DateTime.Now));
        }
        
}
