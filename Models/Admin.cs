namespace ParkingApi.Models
{
    public class Admin : BaseModel
    {
        public string Full_name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] StoredSalt { get; set; }
    }
}
