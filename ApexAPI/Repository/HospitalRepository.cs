using ApexAPI.Models;
using ApexAPI.Interface;

namespace ApexAPI.Repository
{
    public class HospitalRepository : IHospital
    {
        List<Hospital> lsWards = StaticData.lsWards;

        public List<Hospital> GetAllDetails()
        {
            return lsWards.ToList();
        }
        public Hospital GetWardDetailsById(int id)
        {
            return lsWards.FirstOrDefault(f => f.WardId == id);
        }
        public Hospital GetWardWithMaxBedCountAvailable()
        {
            return lsWards.Where(w=>w.AvailableBedsCount == lsWards.Max(m => m.AvailableBedsCount)).FirstOrDefault();
        }
    }
}
