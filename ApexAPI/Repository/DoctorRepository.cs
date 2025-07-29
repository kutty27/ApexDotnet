using ApexAPI.Interface;
using ApexAPI.Models;

namespace ApexAPI.Repository
{
    public class DoctorRepository : IDoctor
    {
        List<Doctor> lsDoctors = StaticData.lsDoctors;

        public List<Doctor> GetAllDoctors()
        {
            return lsDoctors.ToList();
        }
        public List<Doctor> GetDoctorsByWardName(string wardName)
        {
            return lsDoctors.Where(w => w.Hospital.WardName == wardName).ToList();
        }
        public bool AddDoctor(Doctor doctor)
        {
            var isData = lsDoctors.Where(w=>w.Id == doctor.Id).Any();

            if(!isData)
            {
                lsDoctors.Add(doctor);
                return true;
            }
            return false;
        }
        public bool UpdateDoctorContact(int id, long contact)
        {
            if (id == 0 || contact == 0)
                return false;

            Doctor d = lsDoctors.FirstOrDefault(f => f.Id == id);

            if(d != null)
            {
                lsDoctors.FirstOrDefault(f => f.Id == id).Contact = contact;
                return true;
            }
            return false;
        }
        public bool RemoveDoctor(int id)
        {
            Doctor isData = lsDoctors.FirstOrDefault(w => w.Id == id);

            if (isData != null)
            {
                lsDoctors.Remove(isData);
                return true;
            }
            return false;
        }
    }
}
