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
    public class VehicleDAL
    {
        private readonly string _connectionString;

        public VehicleDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertVehicle(VehicleDto vehicle)
        {
            int vehicleId = 0;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlProcedure = "InsertVehicle";
                    var command = new SqlCommand(sqlProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    command.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                    command.Parameters.AddWithValue("@ClientId", vehicle.ClientId);
                    command.Parameters.Add("@VehicleId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                    vehicleId = Convert.ToInt32(command.Parameters["@VehicleId"].Value);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                vehicleId = 0;
            }

            return vehicleId;
        }
    }
}
