namespace MineManagementApi.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string VehicleID { get; set; }
        public int UserId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Speed { get; set; }
        public int Direction { get; set; }
        public DateTime DeviceTime { get; set; }
        public DateTime ServerTime { get; set; }

        public static Location Create(LocationVM vm, DateTime serverTime)
        {
            return new Location
            {
                VehicleID = vm.VehicleID,
                UserId = vm.UserId,
                Latitude = vm.Latitude,
                Longitude = vm.Longitude,
                Speed = vm.Speed,
                Direction = vm.Direction,
                DeviceTime = vm.DeviceTime,
                ServerTime = serverTime
            };
        }
    }
}
