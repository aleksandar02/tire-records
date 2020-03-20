using Core.Entities;

namespace TireRecords.Models
{
    public class TireViewModel
    {
        public int Id { get; set; }
        public int ReceiptId { get; set; }
        public int VehicleId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Position { get; set; }
        public PositionEnum PositionText
        {
            get
            {
                return (PositionEnum)Position;
            }
            set
            {
                
            }
        }
        public string Dimension { get; set; }
        public string Index { get; set; }
        public int DOT { get; set; }
        public double Depth { get; set; }

        public static TireViewModel MapTo(TireDto tireDto)
        {
            var tire = new TireViewModel();

            tire.Id = tireDto.Id;
            tire.ReceiptId = tireDto.ReceiptId;
            tire.VehicleId = tireDto.VehicleId;
            tire.Brand = tireDto.Brand;
            tire.Model = tireDto.Model;
            tire.Position = tireDto.Position;
            tire.Dimension = tireDto.Dimension;
            tire.Index = tireDto.Index;
            tire.DOT = tireDto.DOT;
            tire.Depth = tireDto.Depth;

            return tire;
        }

        public static TireDto MapFrom(TireViewModel tire)
        {
            var tireDto = new TireDto();

            tireDto.Id = tire.Id;
            tireDto.ReceiptId = tire.ReceiptId;
            tireDto.VehicleId = tire.VehicleId;
            tireDto.Brand = tire.Brand;
            tireDto.Model = tire.Model;
            tireDto.Position = tire.Position;
            tireDto.Dimension = tire.Dimension;
            tireDto.Index = tire.Index;
            tireDto.DOT = tire.DOT;
            tireDto.Depth = tire.Depth;

            return tireDto;
        }
    }
}