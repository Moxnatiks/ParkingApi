namespace ParkingApi.Models
{
    public class Valet : BaseModel
    {
        public string Full_name { get; set; }
        public string Phone { get; set; }
        public string Jetton { get; set; }
        public string Email { get; set; }
        public bool IsAccess { get; set; }
        public string Password { get; set; }
        public byte[] StoredSalt { get; set; }
    }
}
