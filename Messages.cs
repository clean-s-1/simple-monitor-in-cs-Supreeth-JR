namespace checker
{
    public static class Messages
    {

        public static string TemperatureMsg(double temperature, bool IsTempHigh)
        {
            var isHighOrLow = IsTempHigh == true ? "High" : "Low";
            return $" {isHighOrLow} Temperature : {temperature}";
        }
        public static string SOCMsg(double soc)
        {
            if (soc <= 30)
            {
                return "Battery low..! Connect to charger.";
            }

            if (soc == 80.0)
            {
                return "Battery is full..! Remove the charger.";
            }

            return "All is well..!";
        }
    }
}
