using System;
using System.Data.SqlClient;

namespace Core.Entities
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ClientId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Chassis { get; set; }
        public int Type { get; set; }

        public static VehicleDto MapTo(SqlDataReader reader)
        {
            var vehicle = new VehicleDto();

            vehicle.Id = Convert.ToInt32(reader["VehicleId"]);
            vehicle.Type = Convert.ToInt32(reader["VehicleType"]);
            vehicle.Brand = Convert.ToString(reader["VehicleBrand"]);
            vehicle.Model = Convert.ToString(reader["VehicleModel"]);
            vehicle.ClientId = Convert.ToInt32(reader["ClientId"]);
            vehicle.RegistrationNumber = Convert.ToString(reader["RegistrationNumber"]);

            return vehicle;
        }
    }
}
