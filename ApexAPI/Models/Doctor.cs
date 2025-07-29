namespace ApexAPI.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public Hospital Hospital { get; set; }
        public long Contact { get; set; }
    }
}
