using CitizenStatistics.Models;
using Microsoft.EntityFrameworkCore;

namespace CitizenStatistics.Services
{
    public class CitizenService : ICitizenService
    {
        private readonly CitizenDbContext _context;

        public CitizenService(CitizenDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public Citizen? GetCitizen(int id)
        {
            return _context.Citizens.Find(id);
        }

        public IList<Citizen> GetCitizens()
        {
            return _context.Citizens.ToList();
        }

        public void AddCitizen(Citizen citizen)
        {
            _context.Citizens.Add(citizen);
            _context.SaveChanges();
        }

        public void RemoveCitizen(int id)
        {
            var citizen = _context.Citizens.Find(id); // Hämta medborgaren från databasen

            if (citizen != null)
            {
                _context.Citizens.Remove(citizen); // Ta bort medborgaren om den existerar
                _context.SaveChanges();
            }
        }


        public void UpdateCitizen(Citizen citizen)
        {
            _context.Citizens.Update(citizen);
            _context.SaveChanges();
        }
    }
}
