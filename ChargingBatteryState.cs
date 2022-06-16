using System;

namespace Checker
{
    class ChargingBatteryState : IBatteryState
    {
        public bool CheckTemperature(float temperature)
        {
            if (temperature < 0 || temperature > 45)
            {
                Console.WriteLine("Temperature is out of range!");
                return false;
            }

            return true;
        }

        public bool CheckStateOfCharge(float stateOfCharge)
        {
            if (stateOfCharge < 20 || stateOfCharge > 80)
            {
                Console.WriteLine("State of Charge is out of range!");
                return false;
            }

            return true;
        }

        public bool CheckChargeRate(float chargeRate)
        {
            if (chargeRate > 0.8)
            {
                Console.WriteLine("Charge Rate is out of range!");
                return false;
            }

            return true;
        }
    }
}
