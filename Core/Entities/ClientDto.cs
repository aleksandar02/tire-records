using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }

        public static ClientDto MapTo(SqlDataReader reader)
        {
            var client = new ClientDto();

            client.Id = Convert.ToInt32(reader["ClientId"]);
            client.FirstName = Convert.ToString(reader["FirstName"]);
            client.LastName = Convert.ToString(reader["LastName"]);
            client.MobilePhone = Convert.ToString(reader["MobilePhone"]);
            client.Email = Convert.ToString(reader["Email"]);

            return client;
        }
    }
}
