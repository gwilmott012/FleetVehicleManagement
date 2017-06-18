using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FleetVehicleManagement.Entities.Tests
{
    [TestClass()]
    public class VehicleTests
    {
        Vehicle vehicle;

        [TestInitialize]
        public void TestInitialise()
        {
            vehicle = new Vehicle();
        }

        [TestMethod()]
        public void GetRevenueTest_DailyRental_OneJourney()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 2 * Constants.Constants.rentalCostPerDay;

            Assert.AreEqual(revenue, expectedRevenue);

        }


        [TestMethod()]
        public void GetRevenueTest_DailyRental_TwoJourneys()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 2 * Constants.Constants.rentalCostPerDay;

            Assert.AreEqual(revenue, expectedRevenue);
        }



        [TestMethod()]
        public void GetRevenueTest_PerKmRental_OneJourney()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 500 * Constants.Constants.rentalCostPerKm;

            Assert.AreEqual(revenue, expectedRevenue);
        }

        [TestMethod()]
        public void GetRevenueTest_PerKmRental_TwoJourneys()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 1000 * Constants.Constants.rentalCostPerKm;

            Assert.AreEqual(revenue, expectedRevenue);
        }


        [TestMethod()]
        public void GetRevenueTest_NoRental_OneJourney()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 0;

            Assert.AreEqual(revenue, expectedRevenue);
        }

        [TestMethod()]
        public void GetRevenueTest_NoRental_TwoJourneys()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 0;

            Assert.AreEqual(revenue, expectedRevenue);
        }


        [TestMethod()]
        public void GetRevenueTest_NoRental_DailyRental_PerKmRental()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 2, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = (0) + (2 * Constants.Constants.rentalCostPerDay) + (500 * Constants.Constants.rentalCostPerKm);

            Assert.AreEqual(revenue, expectedRevenue);
        }



        [TestMethod()]
        public void GetTotalKmsTest_OneJourney()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 500));

            int totalkms = vehicle.GetTotalKms();
            int expectedKms = 500;

            Assert.AreEqual(totalkms, expectedKms);
        }


        [TestMethod()]
        public void GetTotalKmsTest_TwoJourney()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 250));
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 250));

            int totalkms = vehicle.GetTotalKms();
            int expectedKms = 500;

            Assert.AreEqual(totalkms, expectedKms);
        }



        [TestMethod()]
        public void GetTotalKmsTest_NoRental_DailyRental_PerKmRental()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 1, 250));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 250));

            int totalkms = vehicle.GetTotalKms();
            double expectedKms = 500 + 250 + 250;

            Assert.AreEqual(totalkms, expectedKms);
        }



        [TestMethod()]
        public void GetNoActualServicesTest()
        {
            vehicle.AddService(new Service(100));
            vehicle.AddService(new Service(200));

            int noServices = vehicle.GetNoActualServices();

            Assert.AreEqual(2, noServices);
        }

        [TestMethod()]
        public void GetNoExpectedServicesTest()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 1, 250));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 255));

            int totalkms = vehicle.GetTotalKms();
            int numberExpectedServices1 = (int)(totalkms / Constants.Constants.kmsBetweenService);
            int numberExpectedServices2 = vehicle.GetNoExpectedServices();


            Assert.AreEqual(numberExpectedServices1, numberExpectedServices2);
        }



        [TestMethod()]
        public void GetFuelEconomyTest()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 1, 250));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 250));
            vehicle.AddFuelPurchase(new FuelPurchase(25));
            vehicle.AddFuelPurchase(new FuelPurchase(25));
            vehicle.AddFuelPurchase(new FuelPurchase(50));

            double fuelEconomy = vehicle.GetFuelEconomy();
            
            Assert.AreEqual(fuelEconomy, 10.0);
        }

        [TestMethod()]
        public void GetLatestServiceOdometerReadingTest()
        {
            vehicle.AddService(new Service(100));
            vehicle.AddService(new Service(200));
            vehicle.AddService(new Service(300));

            int OdometerReading = vehicle.GetLatestServiceOdometerReading();
            Assert.AreEqual(OdometerReading,300);
        }

        [TestMethod()]
        public void RequiresServiceTest_DoesNotRequireService()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 25));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 1, 100));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 100));
            vehicle.AddService(new Service(100));
            vehicle.AddService(new Service(200));

            bool requiresService = vehicle.RequiresService();

            Assert.IsFalse(requiresService);
        }

        [TestMethod()]
        public void RequiresServiceTest_DoesRequireService()
        {
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 100));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 1, 100));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 100));
            vehicle.AddService(new Service(100));
            vehicle.AddService(new Service(200));

            string tmp = vehicle.ToString();

            bool requiresService = vehicle.RequiresService();

            Assert.IsTrue(requiresService);
        }

    }
}