using System;

namespace Core.Entities
{
    public class FilterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int VehicleType { get; set; }
        public string RNumber { get; set; }

    }
}
