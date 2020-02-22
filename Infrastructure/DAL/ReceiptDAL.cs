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

        public bool InsertReceipt(ClientDto client, VehicleDto vehicle, ReceiptDto receipt, List<TireDto> tires)
        {
            bool result = true;
            SqlTransaction transaction = null;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    transaction = connection.BeginTransaction();

                    string sqlClient = "InsertClient";
                    string sqlVehicle = "InsertVehicle";
                    string sqlReceipt = "InsertReceipt";
                    string sqlTire = "InsertTire";

                    var cmdClient = new SqlCommand(sqlClient, connection, transaction);
                    cmdClient.CommandType = CommandType.StoredProcedure;

                    #region clientParams
                    cmdClient.Parameters.AddWithValue("@FirstName", client.FirstName);
                    cmdClient.Parameters.AddWithValue("@LastName", client.LastName);
                    cmdClient.Parameters.AddWithValue("@MobilePhone", client.MobilePhone);
                    cmdClient.Parameters.AddWithValue("@Email", client.Email);
                    cmdClient.Parameters.Add("@ClientId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    #endregion

                    cmdClient.ExecuteNonQuery();
                    int clientId = Convert.ToInt32(cmdClient.Parameters["@ClientId"].Value);

                    var cmdVehicle = new SqlCommand(sqlVehicle, connection, transaction);
                    cmdVehicle.CommandType = CommandType.StoredProcedure;

                    #region vehicleParams
                    cmdVehicle.Parameters.AddWithValue("@Brand", vehicle.Brand);
                    cmdVehicle.Parameters.AddWithValue("@RegistrationNumber", vehicle.RegistrationNumber);
                    cmdVehicle.Parameters.AddWithValue("@ClientId", clientId);
                    cmdVehicle.Parameters.Add("@VehicleId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    #endregion

                    cmdVehicle.ExecuteNonQuery();
                    int vehicleId = Convert.ToInt32(cmdVehicle.Parameters["@VehicleId"].Value);

                    var cmdReceipt = new SqlCommand(sqlReceipt, connection, transaction);
                    cmdReceipt.CommandType = CommandType.StoredProcedure;

                    #region receiptParams
                    cmdReceipt.Parameters.AddWithValue("@Number", receipt.Number);
                    cmdReceipt.Parameters.AddWithValue("@Message", receipt.Message);
                    cmdReceipt.Parameters.AddWithValue("@UserName", receipt.UserName);
                    cmdReceipt.Parameters.AddWithValue("@CreatedAt", receipt.CreatedAt);
                    cmdReceipt.Parameters.AddWithValue("@VehicleId", vehicleId);
                    cmdReceipt.Parameters.AddWithValue("@ClientId", clientId);
                    cmdReceipt.Parameters.Add("@ReceiptId", SqlDbType.Int).Direction = ParameterDirection.Output;
                    #endregion

                    cmdReceipt.ExecuteNonQuery();
                    int receiptId = Convert.ToInt32(cmdReceipt.Parameters["@ReceiptId"].Value);

                    foreach (var tire in tires)
                    {
                        var cmdTire = new SqlCommand(sqlTire, connection, transaction);
                        cmdTire.CommandType = CommandType.StoredProcedure;

                        #region tireParams
                        cmdTire.Parameters.AddWithValue("@Position", tire.PositionValue);
                        cmdTire.Parameters.AddWithValue("@Brand", tire.Brand);
                        cmdTire.Parameters.AddWithValue("@Model", tire.Model);
                        cmdTire.Parameters.AddWithValue("@Dimension", tire.Dimension);
                        cmdTire.Parameters.AddWithValue("@Index", tire.Index);
                        cmdTire.Parameters.AddWithValue("@DOT", tire.DOT);
                        cmdTire.Parameters.AddWithValue("@Depth", tire.Depth);
                        cmdTire.Parameters.AddWithValue("@VehicleId", vehicleId);
                        cmdTire.Parameters.AddWithValue("@ReceiptId", receiptId);
                        #endregion

                        cmdTire.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();

                string message = ex.Message;
                result = false;
            }

            return result;
        }
    }
}
