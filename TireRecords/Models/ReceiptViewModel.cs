using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TireRecords.Models
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }

        public static ReceiptViewModel MapTo(ReceiptDto receiptDto)
        {
            var receipt = new ReceiptViewModel();

            receipt.Id = receiptDto.Id;
            receipt.Number = receiptDto.Number;
            receipt.UserName = receiptDto.UserName;
            receipt.CreatedAt = receiptDto.CreatedAt;
            receipt.VehicleId = receiptDto.VehicleId;
            receipt.ClientId = receiptDto.ClientId;
            receipt.Message = receiptDto.Message;

            return receipt;
        }

        public static ReceiptDto MapFrom(ReceiptViewModel receipt)
        {
            var receiptDto = new ReceiptDto();

            receiptDto.Id = receipt.Id;
            receiptDto.Number = receipt.Number;
            receiptDto.UserName = receipt.UserName;
            receiptDto.CreatedAt = receipt.CreatedAt;
            receiptDto.VehicleId = receipt.VehicleId;
            receiptDto.ClientId = receipt.ClientId;
            receiptDto.Message = receipt.Message;

            return receiptDto;
        }
    }
}