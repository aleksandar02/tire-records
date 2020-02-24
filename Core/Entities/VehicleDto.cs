using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static VehicleDto MapTo(SqlDataReader reader)
        {
            var vehicle = new VehicleDto();

            vehicle.Id = Convert.ToInt32(reader["VehicleId"]);
            vehicle.Brand = Convert.ToString(reader["Brand"]);
            vehicle.Model = Convert.ToString(reader["Model"]);
            vehicle.ClientId = Convert.ToInt32(reader["ClientId"]);
            vehicle.RegistrationNumber = Convert.ToString(reader["RegistrationNumber"]);

            return vehicle;
        }
    }
}
