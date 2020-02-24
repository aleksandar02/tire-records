using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ClientReceiptDto
    {
        public ClientDto Client { get; set; }
        public VehicleDto Vehicle { get; set; }
        public ReceiptDto Receipt { get; set; }
    }
}
