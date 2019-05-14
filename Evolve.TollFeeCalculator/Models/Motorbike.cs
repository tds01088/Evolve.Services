using Evolve.TollFeeCalculator.Enums;
using Evolve.TollFeeCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evolve.TollFeeCalculator.Models
{
    /// <summary>
    /// klass för Motorbike som Vehicle type
    /// </summary>
    public class Motorbike : IVehicle
    {
        /// <summary>
        /// 
        /// </summary>
        public string RegNo { get; set ; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public VehicleType GetVehicleType()
        {
            return VehicleType.Motorbike;
        }
    }
}
