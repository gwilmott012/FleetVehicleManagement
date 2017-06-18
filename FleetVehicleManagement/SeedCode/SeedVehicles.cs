using FleetVehicleManagement.Entities;
using System.Collections.Generic;

namespace FleetVehicleManagement.SeedCode
{
    public class SeedVehicles
    {

        public List<Vehicle> Vehicles { get; set; }

        public SeedVehicles()
        {
            Vehicles = new List<Vehicle>();
            CreateVehicles();
        }

        private void CreateVehicles()
        {
            Vehicle v1 = new Vehicle(2015,"Honda", "CR-V", "1ABC-001");

            v1.AddJourney(new Journey(Journey.Rental.Daily, 3, 450));
            v1.AddJourney(new Journey(Journey.Rental.None, 3, 50));
            v1.AddJourney(new Journey(Journey.Rental.PerKM, 3, 450));
            v1.AddJourney(new Journey(Journey.Rental.None, 3, 55));

            v1.AddFuelPurchase(new FuelPurchase(25));
            v1.AddFuelPurchase(new FuelPurchase(25));
            v1.AddFuelPurchase(new FuelPurchase(50));

            v1.AddService(new Service(100));
            v1.AddService(new Service(200));
            v1.AddService(new Service(300));
            v1.AddService(new Service(400));
            v1.AddService(new Service(500));
            v1.AddService(new Service(600));
            v1.AddService(new Service(700));
            v1.AddService(new Service(800));
            v1.AddService(new Service(900));


            Vehicle v2 = new Vehicle(2016, "Toyota", "Highlander", "1ABD-002");

            v2.AddJourney(new Journey(Journey.Rental.PerKM, 3, 600));
            v2.AddJourney(new Journey(Journey.Rental.None, 3, 50));
            v2.AddJourney(new Journey(Journey.Rental.PerKM, 3, 450));
            v2.AddJourney(new Journey(Journey.Rental.None, 3, 55));

            v2.AddFuelPurchase(new FuelPurchase(50));
            v2.AddFuelPurchase(new FuelPurchase(50));
            v2.AddFuelPurchase(new FuelPurchase(75));

            v2.AddService(new Service(100));
            v2.AddService(new Service(200));
            v2.AddService(new Service(900));


            Vehicle v3 = new Vehicle(2016, "Ford", "F-150", "1BEC-003");

            v3.AddJourney(new Journey(Journey.Rental.Daily, 5, 450));
            v3.AddJourney(new Journey(Journey.Rental.Daily, 3, 50));
            v3.AddJourney(new Journey(Journey.Rental.PerKM, 3, 700));
            v3.AddJourney(new Journey(Journey.Rental.None, 3, 55));

            v3.AddFuelPurchase(new FuelPurchase(60));
            v3.AddFuelPurchase(new FuelPurchase(60));
            v3.AddFuelPurchase(new FuelPurchase(80));

            v3.AddService(new Service(100));
            v3.AddService(new Service(200));
            v3.AddService(new Service(300));
            v3.AddService(new Service(400));
            v3.AddService(new Service(500));
            v3.AddService(new Service(600));
            v3.AddService(new Service(700));
            v3.AddService(new Service(800));
            v3.AddService(new Service(900));
            v3.AddService(new Service(1000));
            v3.AddService(new Service(1100));
            v3.AddService(new Service(1200));


            Vehicle v4 = new Vehicle(2016, "Mazda", "CX-5", "1BDT-004");

            v4.AddJourney(new Journey(Journey.Rental.PerKM, 5, 450));
            v4.AddJourney(new Journey(Journey.Rental.PerKM, 3, 50));
            v4.AddJourney(new Journey(Journey.Rental.PerKM, 3, 700));
            v4.AddJourney(new Journey(Journey.Rental.PerKM, 3, 55));

            v4.AddFuelPurchase(new FuelPurchase(10));
            v4.AddFuelPurchase(new FuelPurchase(10));
            v4.AddFuelPurchase(new FuelPurchase(5));

            v4.AddService(new Service(100));
            v4.AddService(new Service(200));
            v4.AddService(new Service(300));
            v4.AddService(new Service(400));
            v4.AddService(new Service(500));
            v4.AddService(new Service(600));
            v4.AddService(new Service(700));
            v4.AddService(new Service(800));
            v4.AddService(new Service(900));
            v4.AddService(new Service(1000));
            v4.AddService(new Service(1100));
            v4.AddService(new Service(1200));


            Vehicle v5 = new Vehicle(2017, "Honda", "Civic", "1ABE-005");

            v5.AddJourney(new Journey(Journey.Rental.Daily, 5, 450));

            v5.AddFuelPurchase(new FuelPurchase(10));

            v5.AddService(new Service(100));
            v5.AddService(new Service(200));

            Vehicles.Add(v1);
            Vehicles.Add(v2);
            Vehicles.Add(v3);
            Vehicles.Add(v4);
            Vehicles.Add(v5);
        }
    }
}
