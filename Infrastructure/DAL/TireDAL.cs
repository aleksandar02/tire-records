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
    public class TireDAL
    {
        private readonly string _connectionString;

        public TireDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool InsertTires(List<TireDto> tires)
        {
            bool result = true;

            try
            {
                foreach (var tire in tires)
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        connection.Open();

                        string sqlProcedure = "InsertTire";
                        var command = new SqlCommand(sqlProcedure, connection);
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Position", tire.Position);
                        command.Parameters.AddWithValue("@Brand", tire.Brand);
                        command.Parameters.AddWithValue("@Model", tire.Model);
                        command.Parameters.AddWithValue("@Dimension", tire.Dimension);
                        command.Parameters.AddWithValue("@Index", tire.Index);
                        command.Parameters.AddWithValue("@DOT", tire.DOT);
                        command.Parameters.AddWithValue("@Depth", tire.Depth);
                        command.Parameters.AddWithValue("@VehicleId", tire.VehicleId);
                        command.Parameters.AddWithValue("@ReceiptId", tire.ReceiptId);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                result = false;
            }

            return result;
        }
    }
}
