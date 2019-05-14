using System;
using System.Collections.Generic;
using System.Text;

namespace Evolve.TollFeeCalculator.Interfaces
{
    /// <summary>
    /// interface for Calculate cost Toll
    /// </summary>
    public interface ITollFeeCalculatorService
    {
        /// <summary>
        /// Calculate the total toll fee for one day for a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="dates"></param>
        /// <returns></returns>
        int GetTollFee(IVehicle vehicle, DateTime[] dates);
    }
}
