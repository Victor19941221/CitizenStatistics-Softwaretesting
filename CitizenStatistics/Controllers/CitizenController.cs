using CitizenStatistics.Services;
using CitizenStatistics.Models;
using Microsoft.AspNetCore.Mvc;

namespace CitizenStatistics.Controllers;

public class CitizenController : Controller
{
    private readonly ICitizenService _citizenService;

    // Inject CitizenService through Dependency Injection
    public CitizenController(ICitizenService citizenService)
    {
        _citizenService = citizenService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var citizens = _citizenService.GetCitizens();
        return View(citizens);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Citizen citizen)
    {
        if (string.IsNullOrWhiteSpace(citizen.Profession))
        {
            ModelState.AddModelError("Profession", "Profession is required.");
            return View(citizen);
        }

        _citizenService.AddCitizen(citizen);
        return RedirectToAction("Index");
    }


    

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var citizen = _citizenService.GetCitizen(id);
        return citizen == null ? NotFound() : View(citizen);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var citizen = _citizenService.GetCitizen(id);
        if (citizen == null)
        {
            return NotFound();
        }

        _citizenService.RemoveCitizen(id); // Uppdaterad för att använda `id` istället för `Citizen`
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var citizen = _citizenService.GetCitizen(id);
        return citizen == null ? NotFound() : View(citizen);
    }

    [HttpPost]
    public IActionResult Edit(Citizen citizen)
    {
        if (ModelState.IsValid)
        {
            _citizenService.UpdateCitizen(citizen);
            return RedirectToAction("Index");
        }

        return View(citizen);
    }
}
