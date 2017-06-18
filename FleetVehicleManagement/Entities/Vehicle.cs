using System;
using System.Collections.Generic;
using System.Text;

namespace FleetVehicleManagement.Entities
{
    public class Vehicle
    {
        public int Year { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Registration { get; set; }
        public int TotalKms { get { return GetTotalKms(); } }
        public int TotalServices { get { return GetNoActualServices(); } }
        public double TotalRevenue { get { return GetRevenue(); } }
        public string RequiresServicing { get { return (RequiresService()? "Yes" : "No"); } }

        public List<FuelPurchase> FuelPurchases { get; set; }
        public List<Journey> Journeys { get; set; }
        public List<Service> Services { get; set; }

        public Vehicle()
        {
            FuelPurchases = new List<Entities.FuelPurchase>();
            Journeys = new List<Entities.Journey>();
            Services = new List<Entities.Service>();
        }

        public Vehicle(int _Year, string _Manufacturer, string _Model, string _Registration) : this()
        {
            Year = _Year;
            Manufacturer = _Manufacturer;
            Model = _Model;
            Registration = _Registration;

        }

        public bool RequiresService()
        {
            //Services are required every 100km (this is stored in contants file - kmsBetweenService)
            if ((GetTotalKms() - GetLatestServiceOdometerReading()) >= Constants.Constants.kmsBetweenService)
            {
                return true;
            }

            return false;
        }

        public int GetLatestServiceOdometerReading()
        {
            int latestServiceOdometer = 0;

            foreach (var s in Services)
            {
                if (s.Odometer > latestServiceOdometer)
                {
                    latestServiceOdometer = s.Odometer;
                }
            }

            return latestServiceOdometer;
        }

        public double GetRevenue()
        {
            //Revenue can be calculated from all the Journeys.
            double totalRevenue = 0;

            foreach (var j in Journeys)
            {
                totalRevenue += j.GetRevenue();
            }

            return Math.Round(totalRevenue,2);
        }

        public double GetFuelEconomy()
        {
            //Calculated by getting the Kms travelled and divide by the Litres purchased..
            //Now divide 100 by this number.
            //Return as double to one decimal place (Math.Round).
            double litresPurchased = 0;
            double fuelEconomy = 0;

            foreach (var f in FuelPurchases)
            {
                litresPurchased += f.Litres;
            }

            fuelEconomy = 100 / (GetTotalKms() / litresPurchased);

            return Math.Round(fuelEconomy,1);
        }

        public int GetTotalKms()
        {
            //Add up all KmsTravelled from Journeys
            int totalKmsTravelled = 0;

            foreach (var j in Journeys)
            {
                totalKmsTravelled += j.KmsTravelled;
            }

            return totalKmsTravelled;
        }

        public int GetNoActualServices()
        {
            //Count the number of Services
            return Services.Count;
        }

        public int GetNoExpectedServices()
        {
            //Total Kms travelled divided by the kmsBetweenService value from the constants file
            return (int)(GetTotalKms() / Constants.Constants.kmsBetweenService);
        }

        public void AddFuelPurchase(FuelPurchase fuelPurchase)
        {
            FuelPurchases.Add(fuelPurchase);
        }

        public void AddJourney(Journey journey)
        {
            Journeys.Add(journey);
        }

        public void AddService(Service service)
        {
            Services.Add(service);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Manufacturer: " + Manufacturer);
            sb.AppendLine("Model: " + Model);
            sb.AppendLine("Make Year: " + Year);
            sb.AppendLine("Registration No: " + Registration);
            sb.AppendLine("Total Kilometers Travelled: " + TotalKms + "kms");
            sb.AppendLine("Total services: " + TotalServices);
            sb.AppendLine("Revenue recorded: " + TotalRevenue.ToString("C"));
            sb.AppendLine("Kilometers since the last service: " + (GetTotalKms() - GetLatestServiceOdometerReading()).ToString() + "kms");
            sb.AppendLine("Fuel economy: " + GetFuelEconomy().ToString() + "L/100km");

            //Use Tenary operator to write boolean values as "Yes" or "No"
            sb.AppendLine("Requires a service: " + (RequiresService() ? "Yes" : "No"));

            return sb.ToString();
        }
    }
}
