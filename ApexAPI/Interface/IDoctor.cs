using ApexAPI.Models;

namespace ApexAPI.Interface
{
    public interface IDoctor
    {
        List<Doctor> GetAllDoctors();
        List<Doctor> GetDoctorsByWardName(string wardName);
        bool AddDoctor(Doctor doctor);
        bool UpdateDoctorContact(int id, long contact);
        bool RemoveDoctor(int id);
    }
}
