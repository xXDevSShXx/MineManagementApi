namespace MineManagementApi.Models
{
    public class LocationVM
    {
        public string VehicleID { get; set; }
        public int UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
        public int Direction { get; set; }
        public DateTime DeviceTime { get; set; }
    }
}
