using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Created by Ben Dunn, OCT 11 2016
/// 
/// Creates validation methods for inputs making sure that they contain proper values, used to 
/// reduce code size on the front end. 
/// 
/// </summary>


namespace AssignmentTwo.BackGroundClasses
{
    static class InputTester
    {
        /// <summary>
        /// Simplified method for try parse to remove 
        /// front end glitch checking completely from the form 
        /// for invalid values. This is simply created as a method 
        /// as the actually varient for double.TryParse() is 
        /// not as simplified for this example. While this method
        /// does have an external try/catch the actual value of the
        /// information is just a holder to remove numberous try/catch 
        /// blocks in the main program and contains the proper validation
        /// as this code is not truely a error. (and thus should not throw
        /// an exception other then if I desire to throw it). 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParseDouble(String value)
        {
            try
            {
                Double.Parse(value);
                return true; // as the code will throw an exceptiomn, the try parse will fail and 
                // the exception will catch triggering the event. 

            }catch (Exception)
            {
                return false; 
            }

        }

        /// <summary>
        /// Tries to parse the value, returns false if not a number, also returns 
        /// false if it is not above the value. 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="aboveValue"></param>
        /// <returns></returns>
        public static bool TryParseDoubleNotBelow(String value, double aboveValue)
        {
            try
            {
                double testValue = Double.Parse(value);
                if (testValue >= aboveValue)
                {
                    return true; // as the code will throw an exceptiomn, the try parse will fail and 
                                 // the exception will catch triggering the event. 
                } else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Trys to parse the value, returns false if invalid.
        /// Checks if the value is below the abo
        /// </summary>
        /// <param name="value"></param>
        /// <param name="belowValue"></param>
        /// <returns></returns>
        public static bool TryParseDoubleNotAbove(String value, double belowValue)
        {
            try
            {
                double testValue = Double.Parse(value);
                if (testValue <= belowValue)
                {
                    return true; // as the code will throw an exceptiomn, the try parse will fail and 
                                 // the exception will catch triggering the event. 
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Try parse within the value range, returns false if string invalid, or string
        /// not within the decided range;
        /// </summary>
        /// <param name="value"></param>
        /// <param name="aboveValue"></param>
        /// <param name="belowValue"></param>
        /// <returns></returns>
        public static bool tryParseDoubleBetween (String value, double aboveValue, double belowValue)
        {
            if (TryParseDoubleNotBelow(value, aboveValue)&& TryParseDoubleNotAbove(value, belowValue))
            {
                return true;
            } else { return false; }
        }



    }
}
