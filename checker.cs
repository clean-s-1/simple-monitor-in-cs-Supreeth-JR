namespace Checker
{
    class Checker
    {
        static int Main(string[] args)
        {
            IBatteryState batteryState = ChargingState.GetChargingState(typeof(ChargingBatteryState));

            bool isTempInRange = batteryState.CheckTemperature(32);
            bool isChargingRateInRange = batteryState.CheckChargeRate(0.5f);
            bool isStateOfChargeInRange = batteryState.CheckStateOfCharge(50);

            TestUtilities.ExpectTrue(isTempInRange);
            TestUtilities.ExpectTrue(isChargingRateInRange);
            TestUtilities.ExpectTrue(isStateOfChargeInRange);

            isTempInRange = batteryState.CheckTemperature(50);
            isChargingRateInRange = batteryState.CheckChargeRate(1);
            isStateOfChargeInRange = batteryState.CheckStateOfCharge(90);

            TestUtilities.ExpectFalse(isTempInRange);
            TestUtilities.ExpectFalse(isChargingRateInRange);
            TestUtilities.ExpectFalse(isStateOfChargeInRange);

            return 0;
        }
    }
}
