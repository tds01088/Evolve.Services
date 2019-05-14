using Evolve.TollFeeCalculator.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evolve.TollFeeCalculator.Interfaces
{
    /// <summary>
    /// Vehicle Interface
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// VehicleType 
        /// </summary>
        /// <returns></returns>
        VehicleType GetVehicleType();
        /// <summary>
        /// 
        /// </summary>
        string RegNo { get; }
    }
}
