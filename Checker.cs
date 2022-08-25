namespace checker
{
    using System.Collections.Generic;

    public class Checker
    {
        static int Main()
        {
            List<Cell> cells = new List<Cell>
            {
                new Cell()
                {
                    Current = 3,
                    InputCurrent = 2.5,
                    IsCellActive = true,
                    TimeOfCharging = 1.5f,
                },
                new Cell()
                {
                    Current = 3,
                    InputCurrent = 2.5,
                    IsCellActive = true,
                    TimeOfCharging = 1.5f,
                }
            };

            IBatteryManagementSystem bms = new BatteryManagementSystem(cells,25);
            bms.Charging();
            bms.SocInRange();
            bms.Discharging();
            Messages.TemperatureMsg(25, bms.CheckTemperature());
            Messages.SOCMsg(bms._StateOfCharge);

            return 0;
        }
    }
}
