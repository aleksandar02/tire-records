using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public static ReceiptDto MapFrom(FormCollection collection, string userName)
        {
            var receipt = new ReceiptDto();
            int number = new Random().Next(1, 100);

            receipt.Number = number;
            receipt.Message = Convert.ToString(collection["message"]);
            receipt.UserName = userName;
            receipt.CreatedAt = DateTime.Now;

            return receipt;
        }
    }
}