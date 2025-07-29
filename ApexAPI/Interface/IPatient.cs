using ApexAPI.Models;

namespace ApexAPI.Interface
{
    public interface IPatient
    {
        List<Patient> GetAllPatients();
        bool AddPatient(Patient patient);
        bool UpdatePatientWardName(int id, string wardName);
    }
}
