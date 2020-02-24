using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TireRecords.Models
{
    public class ClientReceiptViewModel
    {
        public ClientViewModel Client { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public ReceiptViewModel Receipt { get; set; }

    }
}