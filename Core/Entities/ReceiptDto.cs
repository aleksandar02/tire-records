using System;
using System.Data.SqlClient;

namespace Core.Entities
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }

        public static ReceiptDto MapTo(SqlDataReader reader)
        {
            var receipt = new ReceiptDto();

            receipt.Id = Convert.ToInt32(reader["ReceiptId"]);
            receipt.Number = Convert.ToInt32(reader["Number"]);
            receipt.UserName = Convert.ToString(reader["UserName"]);
            receipt.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
            receipt.VehicleId = Convert.ToInt32(reader["VehicleId"]);
            receipt.ClientId = Convert.ToInt32(reader["ClientId"]);
            receipt.Message = Convert.ToString(reader["Message"]);

            return receipt;
        }
    }
}
