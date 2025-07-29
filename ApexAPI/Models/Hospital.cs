namespace ApexAPI.Models
{
    public class Hospital
    {
        public int WardId { set; get; }
        public string WardName { set; get; }
        public string HeadDoctorName { set; get; }
        public int AvailableBedsCount { set; get; }
    }
}
