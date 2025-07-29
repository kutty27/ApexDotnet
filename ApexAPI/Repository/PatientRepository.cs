using ApexAPI.Interface;
using ApexAPI.Models;

namespace ApexAPI.Repository
{
    public class PatientRepository : IPatient
    {
        List<Patient> lsPatients = StaticData.lsPatients;

        public List<Patient> GetAllPatients()
        {
            return lsPatients.ToList();
        }
        public bool AddPatient(Patient patient)
        {
            var isData = lsPatients.Where(w => w.Id == patient.Id).Any();

            if (!isData)
            {
                lsPatients.Add(patient);
                return true;
            }
            return false;
        }
        public bool UpdatePatientWardName(int id, string wardName)
        {
            if (id == 0 || wardName == null)
                return false;

            Patient d = lsPatients.FirstOrDefault(f => f.Id == id);

            if (d != null)
            {
                lsPatients.FirstOrDefault(f => f.Id == id).Hospital.WardName = wardName;
                return true;
            }
            return false;
        }
    }
}
