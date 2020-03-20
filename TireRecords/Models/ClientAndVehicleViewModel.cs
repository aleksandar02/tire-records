using Core.Entities;
using System;

namespace TireRecords.Models
{
    public class ClientAndVehicleViewModel
    {
        public ClientViewModel Client { get; set; }
        public VehicleViewModel Vehicle { get; set; }

        public static ClientAndVehicleViewModel MapTo(ClientAndVehicleDto clientAndVehicleDto)
        {
            var clientAndVehicle = new ClientAndVehicleViewModel();

            clientAndVehicle.Client = ClientViewModel.MapTo(clientAndVehicleDto.Client);
            clientAndVehicle.Vehicle = VehicleViewModel.MapTo(clientAndVehicleDto.Vehicle);

            return clientAndVehicle;
        }
    }
}