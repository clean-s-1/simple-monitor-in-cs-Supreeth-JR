namespace checker
{
    class Cell
    {
        public double MaximumCapacity = 25; // 25Ah (amps/hour)
        public double Current { get; set; }

        public double InputCurrent { get; set; }
        public float TimeOfCharging { get; set; }
        public double StateOfCharge
        {
            get
            {
                return ((InputCurrent * TimeOfCharging) / MaximumCapacity);
            }
            set { }
        }
        public bool IsCellActive { get; set; }
    }
}
