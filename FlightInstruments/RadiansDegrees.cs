using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightInstruments
{
    public static class MathExtensions
    {
        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="degrees">The angle in degrees.</param>
        /// <returns>The angle in radians.</returns>
        public static double ToRadians(this double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        /// <summary>
        /// Converts radians to degrees.
        /// </summary>
        /// <param name="radians">The angle in radians.</param>
        /// <returns>The angle in degrees.</returns>
        public static double ToDegrees(this double radians)
        {
            return radians * (180 / Math.PI);
        }
    }
}
