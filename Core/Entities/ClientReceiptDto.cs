﻿namespace Core.Entities
{
    public class ClientReceiptDto
    {
        public ClientDto Client { get; set; }
        public VehicleDto Vehicle { get; set; }
        public ReceiptDto Receipt { get; set; }
    }
}
