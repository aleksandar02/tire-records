using Core.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DAL
{
    public class ReceiptDAL
    {
        private readonly string _connectionString;

        public ReceiptDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertReceipt(ReceiptDto receipt)
        {
            int receiptId = 0;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlProcedure = "InsertReceipt";
                    var command = new SqlCommand(sqlProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Number", receipt.Number);
                    command.Parameters.AddWithValue("@Message", receipt.Message);
                    command.Parameters.AddWithValue("@UserName", receipt.UserName);
                    command.Parameters.AddWithValue("@CreatedAt", receipt.CreatedAt);
                    command.Parameters.AddWithValue("@VehicleId", receipt.VehicleId);
                    command.Parameters.AddWithValue("@ClientId", receipt.ClientId);
                    command.Parameters.Add("@ReceiptId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                    receiptId = Convert.ToInt32(command.Parameters["@ReceiptId"].Value);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                receiptId = 0;
            }

            return receiptId;
        }

        //public async Task<int> CountReceiptRows()
        //{
            
        //}
    }
}
