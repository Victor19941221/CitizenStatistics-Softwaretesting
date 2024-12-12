using CitizenStatistics.Models;

namespace CitizenStatistics
{
    public interface ICitizenService
    {
        Citizen? GetCitizen(int id);
        IList<Citizen> GetCitizens();
        void AddCitizen(Citizen citizen);
        void RemoveCitizen(int id);
        void UpdateCitizen(Citizen citizen);
    }
}
