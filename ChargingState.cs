using System;

namespace Checker
{
    public static class ChargingState
    {
        public static IBatteryState GetChargingState(Type classType)
        {
            return (IBatteryState)Activator.CreateInstance(classType);
        }
    }
}
