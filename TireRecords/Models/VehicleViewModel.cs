using Core.Entities;
using System;
using System.Web.Mvc;

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
        public int Type { get; set; }
        public string TypeText
        {
            get
            {
                if (Type == 1) return "Putničko vozilo";
                else if (Type == 2) return "Teretno vozilo";
                else return "";
            }
        }
        public static VehicleViewModel MapTo(VehicleDto vehicleDto)
        {
            var vehicle = new VehicleViewModel();

            vehicle.Id = vehicleDto.Id;
            vehicle.Brand = vehicleDto.Brand;
            vehicle.Model = vehicleDto.Model;
            vehicle.ClientId = vehicleDto.ClientId;
            vehicle.RegistrationNumber = vehicleDto.RegistrationNumber;
            vehicle.Chassis = vehicleDto.Chassis;
            vehicle.Type = vehicleDto.Type;

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
            vehicleDto.Type = vehicle.Type;

            return vehicleDto;
        }

        public static VehicleDto MapFrom(FormCollection collection)
        {
            var vehicle = new VehicleDto();

            vehicle.Type = Convert.ToInt32(collection["vehicleType"]);
            vehicle.Brand = Convert.ToString(collection["vehicleBrand"]);
            vehicle.RegistrationNumber = Convert.ToString(collection["registrationNumber"]);

            return vehicle;
        }
    }
}