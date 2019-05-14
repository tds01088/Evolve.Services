using Evolve.TollFeeCalculator.Extensions;
using Evolve.TollFeeCalculator.Interfaces;
using Evolve.TollFeeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Evolve.TollFeeCalculator.Services
{
    /// <summary>
    /// Service for Calculate cost Toll
    /// </summary>
    public class TollFeeCalculatorService : ITollFeeCalculatorService
    {
        /// <summary>
        /// Calculate the total toll fee for one day for a vehicle
        /// </summary>
        /// <param name="vehicle"></param>
        /// <param name="dates"></param>
        /// <returns>total cost toll fee for one day</returns>
        public int GetTollFee(IVehicle vehicle, DateTime[] dates)
        {
            DateTime intervalStart = dates[0];
            int totalFee = 0;
            foreach (DateTime date in dates)
            {
                int nextFee = GetTollFee(date, vehicle);
                int tempFee = GetTollFee(intervalStart, vehicle);

                long diffInMillies = date.Millisecond - intervalStart.Millisecond;
                long minutes = diffInMillies / 1000 / 60;

                if (minutes <= Globals.AppConfiguration.CostParameters.MaxDiffInMinutes)
                {
                    if (totalFee > 0) totalFee -= tempFee;
                    if (nextFee >= tempFee) tempFee = nextFee;
                    totalFee += tempFee;
                }
                else
                {
                    totalFee += nextFee;
                }
            }
            var MaxtotalCost = Globals.AppConfiguration.CostParameters.MaxtotalCost;
            if (totalFee > MaxtotalCost) totalFee = MaxtotalCost;
            return totalFee;
        }
        /// <summary>
        /// Get toll fee by time
        /// </summary>
        /// <param name="date"></param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        private int GetTollFee(DateTime date, IVehicle vehicle)
        {
            if (vehicle.IsTollFreeVehicle() || date.IsTollFreeDate()) return 0;
            var costTime = new CostTime(date.Hour, date.Minute);
            return costTime.GetAmountOfTime();
        }
    }
}

