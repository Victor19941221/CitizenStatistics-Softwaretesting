using CitizenStatistics.Models;
using CitizenStatistics.Services;
using Microsoft.AspNetCore.Mvc;

namespace CitizenStatistics.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitizenService _citizenService;

        public HomeController(ICitizenService citizenService)
        {
            _citizenService = citizenService;
        }

        public IActionResult Index()
        {
            var citizens = _citizenService.GetCitizens();

            var statisticsService = new StatisticsService(citizens);
            var statistics = new Statistics()
            {
                AverageAge = statisticsService.AverageAge(),
                MedianAge = statisticsService.MedianAge(),
                HighestIncome = statisticsService.HighestIncome(),
                LowestIncome = statisticsService.LowestIncome(),
                TopPayingProfessions = statisticsService.TopPayingProfessions(3),
            };

            return View(statistics);
        }
    }
}
