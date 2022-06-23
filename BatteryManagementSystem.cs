namespace checker
{
    using System.Collections.Generic;
    using System.Linq;
    class BatteryManagementSystem : IBatteryManagementSystem
    {
        public double _MaximumCapacity { get; set; }

        public double _StateOfCharge { get; set; }

        public double _Temperature { get; set; }

        private IEnumerable<Cell> _Cells;
        public BatteryManagementSystem(
            IEnumerable<Cell> cells,
            double temperature)
        {
            _Temperature = temperature;
            CalculateMaxBatteryCapacity();
        }

        public void PassiveBalancing()
        {
            var maxCurrentInCell = _Cells.Max(x => x.Current);
            var lessCurrentCell = _Cells.Where(x => x.Current <= maxCurrentInCell).ToList();
            if (lessCurrentCell.Count > 0)
            {
                _Cells.Where(x => x.Current <= maxCurrentInCell).ToList().ForEach(x =>
                {
                    x.IsCellActive = false;
                });
            }
        }

        public bool CheckTemperature()
        {
            return _Temperature >= 10 && _Temperature <= 55;
        }

        public void Charging()
        {
            if (CheckTemperature())
            {
                double charge = 0.0;
                foreach (var cell in _Cells)
                {
                    if (_StateOfCharge <= 80)
                    {
                        charge += cell.StateOfCharge;
                    }
                    else
                    {
                        return;
                    }
                }

                _StateOfCharge = charge / _Cells.Count();
            }
        }

        public void Discharging()
        {
            if (CheckTemperature())
            {
                PassiveBalancing();
                _Cells.Where(x => x.IsCellActive).ToList().ForEach(x =>
                  {
                      x.StateOfCharge -= x.StateOfCharge;
                  });
            }
        }

        public bool SocInRange()
        {
            return _StateOfCharge > 30 && _StateOfCharge < 80;
        }

        private void CalculateMaxBatteryCapacity()
        {
            _Cells.ToList().ForEach(x =>
            {
                _MaximumCapacity += x.MaximumCapacity;
            });
        }
    }
}
