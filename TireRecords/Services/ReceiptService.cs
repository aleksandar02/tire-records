using Core.Entities;
using Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TireRecords.Models;

namespace TireRecords.Services
{
    public class ReceiptService
    {
        private ReceiptDAL _receiptDAL;
        private ClientDAL _clientDAL;
        private VehicleDAL _vehicleDAL;
        private TireDAL _tireDAL;

        public ReceiptService(string connectionString)
        {
            _receiptDAL = new ReceiptDAL(connectionString);
            _clientDAL = new ClientDAL(connectionString);
            _vehicleDAL = new VehicleDAL(connectionString);
            _tireDAL = new TireDAL(connectionString);
        }

        public int InsertClient(ClientDto client)
        {
            return _clientDAL.InsertClient(client);
        }

        public int InsertVehicle(VehicleDto vehicleDto)
        {
            return _vehicleDAL.InsertVehicle(vehicleDto);
        }

        public int InsertReceipt(ReceiptDto receipt)
        {
            return _receiptDAL.InsertReceipt(receipt);
        }

        public bool InsertTires(List<TireDto> tires)
        {
            return _tireDAL.InsertTires(tires);
        }

        public int InsertReceipt(ClientDto client, VehicleDto vehicle, ReceiptDto receipt, List<TireDto> tires)
        {
            return _receiptDAL.InsertReceipt(client, vehicle, receipt, tires);
        }

        public async Task<List<ClientReceiptDto>> SearchReceipts(FilterDto filter)
        {
            return await _receiptDAL.SearchReceipts(filter);
        }

        public async Task<ReceiptDetailsDto> GetReceiptDetails(int id)
        {
            return await _receiptDAL.GetReceiptDetails(id);
        }
    }
}