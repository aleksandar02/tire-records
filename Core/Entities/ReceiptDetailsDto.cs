using System.Collections.Generic;

namespace Core.Entities
{
    public class ReceiptDetailsDto
    {
        public ClientDto Client { get; set; }
        public VehicleDto Vehicle { get; set; }
        public ReceiptDto Receipt { get; set; }
        public List<TireDto> Tires { get; set; }
    }
}
