namespace Checker
{
    public interface IBatteryState
    {
        bool CheckTemperature(float temperature);
        bool CheckStateOfCharge(float stateOfCharge);
        bool CheckChargeRate(float chargeRate);
    }
}
