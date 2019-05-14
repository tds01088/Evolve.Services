using System;
using System.Collections.Generic;
using System.Text;

namespace Evolve.TollFeeCalculator.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class CostTime
    {
        /// <summary>
        /// 
        /// </summary>
        public int Hour { get; }
        /// <summary>
        /// 
        /// </summary>
        public int Minute { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        public CostTime(int hour, int minute) => (Hour, Minute) = (hour, minute);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hour"></param>
        /// <param name="minute"></param>
        public void Deconstruct(out int hour, out int minute) => (hour, minute) = (Hour, Minute);
    }
}
