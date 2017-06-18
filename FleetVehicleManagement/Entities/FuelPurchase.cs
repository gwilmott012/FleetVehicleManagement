using System;

namespace FleetVehicleManagement.Entities
{
    public class FuelPurchase
    {
        public Double Litres { get; set; }

        public FuelPurchase()
        {

        }

        public FuelPurchase(Double _Litres)
        {
            Litres = _Litres;
        }
    }
}
