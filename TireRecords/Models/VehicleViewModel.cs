using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TireRecords.Models
{
    public class VehicleViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ClientId { get; set; }
        public string RegistrationNumber { get; set; }
        public string Chassis { get; set; }

        public static VehicleViewModel MapTo(VehicleDto vehicleDto)
        {
            var vehicle = new VehicleViewModel();

            vehicle.Id = vehicleDto.Id;
            vehicle.Brand = vehicleDto.Brand;
            vehicle.Model = vehicleDto.Model;
            vehicle.ClientId = vehicleDto.ClientId;
            vehicle.RegistrationNumber = vehicleDto.RegistrationNumber;
            vehicle.Chassis = vehicleDto.Chassis;

            return vehicle;
        }

        public static VehicleDto MapFrom(VehicleViewModel vehicle)
        {
            var vehicleDto = new VehicleDto();

            vehicleDto.Id = vehicle.Id;
            vehicleDto.Brand = vehicle.Brand;
            vehicleDto.Model = vehicle.Model;
            vehicleDto.ClientId = vehicle.ClientId;
            vehicleDto.RegistrationNumber = vehicle.RegistrationNumber;
            vehicleDto.Chassis = vehicle.Chassis;

            return vehicleDto;
        }
    }
}