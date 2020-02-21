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
    public class ClientDAL
    {
        private readonly string _connectionString;

        public ClientDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertClient(ClientDto client)
        {
            int clientId = 0;

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string sqlProcedure = "InsertClient";
                    var command = new SqlCommand(sqlProcedure, connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", client.FirstName);
                    command.Parameters.AddWithValue("@LastName", client.LastName);
                    command.Parameters.AddWithValue("@MobilePhone", client.MobilePhone);
                    command.Parameters.AddWithValue("@Email", client.Email);
                    command.Parameters.Add("@ClientId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    command.ExecuteNonQuery();
                    clientId = Convert.ToInt32(command.Parameters["@ClientId"].Value);
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                clientId = 0;
            }

            return clientId;
        }
    }
}
