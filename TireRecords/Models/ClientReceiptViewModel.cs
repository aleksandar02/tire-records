using Core.Entities;
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

        public static List<ClientReceiptViewModel> MapTo(List<ClientReceiptDto> clientReceiptDtos)
        {
            var clientReceiptViewModels = new List<ClientReceiptViewModel>();

            foreach (var receipt in clientReceiptDtos)
            {
                var clientReceipt = new ClientReceiptViewModel();

                clientReceipt.Client = ClientViewModel.MapTo(receipt.Client);
                clientReceipt.Vehicle = VehicleViewModel.MapTo(receipt.Vehicle);
                clientReceipt.Receipt = ReceiptViewModel.MapTo(receipt.Receipt);

                clientReceiptViewModels.Add(clientReceipt);
            }


            return clientReceiptViewModels;
        }
    }
}