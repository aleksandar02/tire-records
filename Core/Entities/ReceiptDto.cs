using System;
using System.Data.SqlClient;

namespace Core.Entities
{
    public class ReceiptDto
    {
        public int Id { get; set; }
        public string RNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }
        public string ClosedBy { get; set; }
        public int Status { get; set; }
        public DateTime? ClosedAt { get; set; }

        public static ReceiptDto MapTo(SqlDataReader reader)
        {
            var receipt = new ReceiptDto();

            receipt.Id = Convert.ToInt32(reader["ReceiptId"]);
            receipt.RNumber = Convert.ToString(reader["RNumber"]);
            receipt.UserName = Convert.ToString(reader["UserName"]);
            receipt.CreatedAt = Convert.ToDateTime(reader["CreatedAt"]);
            receipt.VehicleId = Convert.ToInt32(reader["VehicleId"]);
            receipt.ClientId = Convert.ToInt32(reader["ClientId"]);
            receipt.Message = Convert.ToString(reader["Message"]);
            receipt.ClosedBy = !string.IsNullOrEmpty(reader["ClosedBy"].ToString()) ? reader["ClosedBy"].ToString() : "";
            receipt.ClosedAt = string.IsNullOrEmpty(reader["ClosedAt"].ToString())
              ? (DateTime?)null
              : DateTime.Parse(reader["ClosedAt"].ToString());
            receipt.Status = Convert.ToInt32(reader["Status"]);
          

            return receipt;
        }
    }
}
