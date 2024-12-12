using CitizenStatistics.Models;
using System.Linq;

namespace CitizenStatistics.Services
{
    public class StatisticsService
    {
        private readonly IList<Citizen> _citizens;

        public StatisticsService(IList<Citizen> citizens)
        {
            _citizens = citizens;
        }

        public int AverageAge()
        {
            if (!_citizens.Any())
            {
                return 0; // Return 0 when there are no citizens
            }
            return (int)_citizens.Average(c => c.Age);
        }

        public int MedianAge()
        {
            if (!_citizens.Any())
            {
                return 0; // Return 0 if no citizens exist
            }

            var sortedAges = _citizens.Select(c => c.Age).OrderBy(age => age).ToList();
            int count = sortedAges.Count;
            if (count % 2 == 0)
            {
                return (sortedAges[count / 2 - 1] + sortedAges[count / 2]) / 2;
            }
            return sortedAges[count / 2];
        }

        public int HighestIncome()
        {
            if (!_citizens.Any())
            {
                return 0; // Return 0 if no citizens exist
            }
            return _citizens.Max(c => c.Income);
        }

        public int LowestIncome()
        {
            if (!_citizens.Any())
            {
                return 0; // Return 0 if no citizens exist
            }
            return _citizens.Min(c => c.Income);
        }

        public string[] TopPayingProfessions(int count)
        {
            if (!_citizens.Any())
            {
                return new string[0]; // Return empty array if no citizens exist
            }

            return _citizens
                .OrderByDescending(c => c.Income)
                .Select(c => c.Profession)
                .Distinct()
                .Take(count)
                .ToArray();
        }
    }
}
