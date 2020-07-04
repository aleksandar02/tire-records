using Core.Entities;
using System;
using System.Web.Mvc;

namespace TireRecords.Models
{
    public class ReceiptViewModel
    {
        public int Id { get; set; }
        public string RNumber { get; set; }
        public string UserName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int VehicleId { get; set; }
        public int ClientId { get; set; }
        public string Message { get; set; }
        public string ClosedBy { get; set; }
        public int Status { get; set; }
        public DateTime? ClosedAt { get; set; }

        public static ReceiptViewModel MapTo(ReceiptDto receiptDto)
        {
            var receipt = new ReceiptViewModel();

            receipt.Id = receiptDto.Id;
            receipt.RNumber = receiptDto.RNumber;
            receipt.UserName = receiptDto.UserName;
            receipt.CreatedAt = receiptDto.CreatedAt;
            receipt.VehicleId = receiptDto.VehicleId;
            receipt.ClientId = receiptDto.ClientId;
            receipt.Message = receiptDto.Message;
            receipt.ClosedBy = receiptDto.ClosedBy;
            receipt.Status = receiptDto.Status;
            receipt.ClosedAt = receiptDto.ClosedAt;

            return receipt;
        }

        public static ReceiptDto MapFrom(ReceiptViewModel receipt)
        {
            var receiptDto = new ReceiptDto();

            receiptDto.Id = receipt.Id;
            receiptDto.RNumber = receipt.RNumber;
            receiptDto.UserName = receipt.UserName;
            receiptDto.CreatedAt = receipt.CreatedAt;
            receiptDto.VehicleId = receipt.VehicleId;
            receiptDto.ClientId = receipt.ClientId;
            receiptDto.Message = receipt.Message;
            receiptDto.ClosedBy = receipt.ClosedBy;
            receiptDto.Status = receipt.Status;
            receiptDto.ClosedAt = receipt.ClosedAt;

            return receiptDto;
        }

        public static ReceiptDto MapFrom(FormCollection collection, string userName)
        {
            var receipt = new ReceiptDto();

            receipt.Message = Convert.ToString(collection["message"]);
            receipt.UserName = userName;
            receipt.CreatedAt = DateTime.Now;
            receipt.ClosedAt = DateTime.Now;
            receipt.Status = 1;

            return receipt;
        }
    }
}