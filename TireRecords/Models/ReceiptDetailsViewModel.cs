using System.Collections.Generic;
using Core.Entities;

namespace TireRecords.Models
{
    public class ReceiptDetailsViewModel
    {
        public ClientViewModel Client { get; set; }
        public VehicleViewModel Vehicle { get; set; }
        public ReceiptViewModel Receipt { get; set; }
        public List<TireViewModel> Tires { get; set; }

        public static ReceiptDetailsViewModel MapTo(ReceiptDetailsDto receiptDetailsDtos)
        {
            var receiptDetails = new ReceiptDetailsViewModel();

            receiptDetails.Client = ClientViewModel.MapTo(receiptDetailsDtos.Client);
            receiptDetails.Vehicle = VehicleViewModel.MapTo(receiptDetailsDtos.Vehicle);
            receiptDetails.Receipt = ReceiptViewModel.MapTo(receiptDetailsDtos.Receipt);
            receiptDetails.Tires = new List<TireViewModel>();

            foreach (var tireDto in receiptDetailsDtos.Tires)
            {
                var tire = TireViewModel.MapTo(tireDto);

                receiptDetails.Tires.Add(tire);
            }

            return receiptDetails;
        }
    }
}