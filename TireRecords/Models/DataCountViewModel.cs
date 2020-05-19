using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TireRecords.Models
{
    public class DataCountViewModel
    {
        public int ReceiptsCount { get; set; }
        public int VehicleType1Count { get; set; }
        public int VehicleType2Count { get; set; }

        public static DataCountViewModel MapTo(DataCountDto dataCountDto)
        {
            var dataCount = new DataCountViewModel();

            dataCount.ReceiptsCount = dataCountDto.ReceiptsCount;
            dataCount.VehicleType1Count = dataCountDto.VehicleType1Count;
            dataCount.VehicleType2Count = dataCountDto.VehicleType2Count;

            return dataCount;
        }
    }
}