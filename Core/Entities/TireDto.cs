using System;
using System.Data.SqlClient;

namespace Core.Entities
{
    public class TireDto
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Position { get; set; }
        public string Dimension { get; set; }
        public string Index { get; set; }
        public int DOT { get; set; }
        public double Depth { get; set; }

        public static TireDto MapTo(SqlDataReader reader)
        {
            var tire = new TireDto();

            tire.Id = Convert.ToInt32(reader["TireId"]);
            tire.Position = Convert.ToInt32(reader["Position"]);
            tire.Model = Convert.ToString(reader["TireModel"]);
            tire.Brand = Convert.ToString(reader["TireBrand"]);
            tire.ReceiptId = Convert.ToInt32(reader["ReceiptId"]);
            tire.Index = Convert.ToString(reader["Index"]);
            tire.VehicleId = Convert.ToInt32(reader["VehicleId"]);
            tire.DOT = Convert.ToInt32(reader["DOT"]);
            tire.Dimension = Convert.ToString(reader["Dimension"]);
            tire.Depth = Convert.ToDouble(reader["Depth"]);

            return tire;
        }
    }
}
