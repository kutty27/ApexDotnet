using ApexAPI.Models;

namespace ApexAPI.Interface
{
    public interface IHospital
    {
        List<Hospital> GetAllDetails();
        Hospital GetWardDetailsById(int id);
        Hospital GetWardWithMaxBedCountAvailable();
    }
}
