namespace checker
{
    interface IBatteryManagementSystem
    {
        double _MaximumCapacity { get; set; }
        double _StateOfCharge { get; set; }
        double _Temperature { get; set; }
        void PassiveBalancing();
        bool CheckTemperature();
        void Charging();
        void Discharging();
        bool SocInRange();
    }

}
