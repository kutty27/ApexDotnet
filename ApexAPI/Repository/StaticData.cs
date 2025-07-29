using ApexAPI.Models;   
namespace ApexAPI.Repository
{
    public class StaticData
    {
        public static List<Hospital> lsWards = new List<Hospital>
        {
            new Hospital{WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul"},
            new Hospital{WardId = 101, WardName = "General", AvailableBedsCount = 50, HeadDoctorName = "Fathima Begum"},
            new Hospital{WardId = 102, WardName = "Special", AvailableBedsCount = 30, HeadDoctorName = "Manoj Marcus"}
        };

        public static List<Doctor> lsDoctors = new List<Doctor>
        {
            new Doctor{Id = 1121, FirstName = "Gokila", LastName = "Harsha", Gender = "Female", Hospital = new Hospital{WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul"}, Contact = 9129540430},
            new Doctor{Id = 1122, FirstName = "Gokul", LastName = "Nath", Gender = "Male", Hospital = new Hospital{WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul"}, Contact = 9129540431},
            new Doctor{Id = 1123, FirstName = "Joy", LastName = "Regis", Gender = "Male", Hospital = new Hospital{WardId = 101, WardName = "General", AvailableBedsCount = 50, HeadDoctorName = "Fathima Begum"}, Contact = 9129540432},
            new Doctor{Id = 1124, FirstName = "Shobana", LastName = "Ramesh", Gender = "Female", Hospital = new Hospital{WardId = 101, WardName = "General", AvailableBedsCount = 50, HeadDoctorName = "Fathima Begum"}, Contact = 9129540433},
            new Doctor{Id = 1125, FirstName = "Mercy", LastName = "Golda", Gender = "Female", Hospital = new Hospital{WardId = 102, WardName = "Special", AvailableBedsCount = 30, HeadDoctorName = "Manoj Marcus"}, Contact = 9129540434}

        };

        public static List<Patient> lsPatients = new List<Patient>
        {
            new Patient{Id = 10110, FirstName = "Sathya", LastName = "Pitachya", Gender = "Female", Hospital = new Hospital{WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul"},BedNumber = 22, Contact = 9952778512 },
            new Patient{Id = 10111, FirstName = "Fathima", LastName = "Resuvana", Gender = "Female", Hospital = new Hospital{WardId = 100, WardName = "Emergency", AvailableBedsCount = 25, HeadDoctorName = "Alex Paul"},BedNumber = 15, Contact = 8127800190 },
            new Patient{Id = 10112, FirstName = "Nandy", LastName = "Rexhana", Gender = "Female", Hospital = new Hospital{WardId = 101, WardName = "General", AvailableBedsCount = 50, HeadDoctorName = "Fathima Begum"},BedNumber = 3, Contact = 9092087423 },
            new Patient{Id = 10113, FirstName = "Sam", LastName = "Clitus", Gender = "Male", Hospital = new Hospital{WardId = 102, WardName = "Special", AvailableBedsCount = 30, HeadDoctorName = "Manoj Marcus"},BedNumber = 13, Contact = 7854465190 }
        };
    }   
}
