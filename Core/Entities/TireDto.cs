using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class TireDto
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public PositionEnum Position { get; set; }
        public int PositionValue { get; set; }
        public string Dimension { get; set; }
        public string Index { get; set; }
        public int DOT { get; set; }
        public double Depth { get; set; }
    }
}
