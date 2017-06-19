using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FleetVehicleManagement.Entities.Tests
{
    [TestClass()]
    public class VehicleTests
    {
        Vehicle vehicle;

        [TestInitialize]
		// upon running tests this will create a new vehicle for any test
        public void TestInitialise()
        {
            vehicle = new Vehicle();
        }

        [TestMethod()]
        public void GetRevenueTest_DailyRental_OneJourney()
        {
			// Tests that vehicle.getrevenue equals a daily journey of two days * the rental cost per day
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 2 * Constants.Constants.rentalCostPerDay;

            Assert.AreEqual(revenue, expectedRevenue);

        }


        [TestMethod()]
        public void GetRevenueTest_DailyRental_TwoJourneys()
        {
			// Tests that vehicle.getrevenue equals two daily journeys of one day * the rental cost per day
			vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.Daily, 1, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 2 * Constants.Constants.rentalCostPerDay;

            Assert.AreEqual(revenue, expectedRevenue);
        }



        [TestMethod()]
        public void GetRevenueTest_PerKmRental_OneJourney()
        {
			// Tests that vehicle.getrevenue equals one per kilometer journey of 500km * the rental cost per kilometer
			vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 500 * Constants.Constants.rentalCostPerKm;

            Assert.AreEqual(revenue, expectedRevenue);
        }

        [TestMethod()]
        public void GetRevenueTest_PerKmRental_TwoJourneys()
        {
			// Tests that vehicle.getrevenue equals one per kilometer journey of 1000 * the rental cost per kilometer
			vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 1000 * Constants.Constants.rentalCostPerKm;

            Assert.AreEqual(revenue, expectedRevenue);
        }


        [TestMethod()]
        public void GetRevenueTest_NoRental_OneJourney()
        {
			// tests that vehicle.getrevenue for one no rental journey equals 0
			vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 0;

            Assert.AreEqual(revenue, expectedRevenue);
        }

        [TestMethod()]
        public void GetRevenueTest_NoRental_TwoJourneys()
        {
			// Tests that vehicle.getrevenue of two no rent journey equals 0
			vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));
            vehicle.AddJourney(new Journey(Journey.Rental.None, 2, 500));

            double revenue = vehicle.GetRevenue();
            double expectedRevenue = 0;

            Assert.AreEqual(revenue, expectedRevenue);
        }


        [TestMethod()]
        public void GetRevenueTest_NoRental_DailyRental_PerKmRental()
        {
			// Tests that vehicle.getrevenue of one per kilometer journey of 500KM, one daily journey of 2 days
			// and one no rent journey equals 0 + 2 * the rental cost per day 1000 + 500 * the rental cost per kilometer
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
			// Tests that vehicle.gettotalkms of one per km journey of 500Km equals 500
			vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 500));

            int totalkms = vehicle.GetTotalKms();
            int expectedKms = 500;

            Assert.AreEqual(totalkms, expectedKms);
        }


        [TestMethod()]
        public void GetTotalKmsTest_TwoJourney()
        {
			// Tests that vehicle.gettotalkms of two per km journey of 250Km equals 500
			vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 250));
            vehicle.AddJourney(new Journey(Journey.Rental.PerKM, 1, 250));

            int totalkms = vehicle.GetTotalKms();
            int expectedKms = 500;

            Assert.AreEqual(totalkms, expectedKms);
        }



        [TestMethod()]
        public void GetTotalKmsTest_NoRental_DailyRental_PerKmRental()
        {
			// Tests that vehicle.gettotalkms of one per km journey of 500Km, one no rent journey and one daily journey of one day equals 500 + 250 + 250
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
			// Tests that vehicle.getNoActualServices of one service at 100 and one service at 200 equals 2
			vehicle.AddService(new Service(100));
            vehicle.AddService(new Service(200));

            int noServices = vehicle.GetNoActualServices();

            Assert.AreEqual(2, noServices);
        }

        [TestMethod()]
        public void GetNoExpectedServicesTest()
        {
			// Tests that vehicle.gettotalkms / kmBetweenService of one per km journey of 500Km, one no rent journey and one daily journey of one day
			// equals vehicle.getNoExpectedServices
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
			// Tests that vehicle.getfueleconomy of one per km journey of 500km, one no rent journey and one 1 day daily journey
			// and three fuel purchases 2 of 25 one of 50 equals 10
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
			// Tests that vehicle.getodometerreading of three services one at 100, 200, 300 equals 300
			vehicle.AddService(new Service(100));
            vehicle.AddService(new Service(200));
            vehicle.AddService(new Service(300));

            int OdometerReading = vehicle.GetLatestServiceOdometerReading();
            Assert.AreEqual(OdometerReading,300);
        }

        [TestMethod()]
        public void RequiresServiceTest_DoesNotRequireService()
        {
			// Tests that vehicle.requiresService of two services one at 100 and 200 and one no rent journey, 1 day daily journey and one perKm of 25km journey is false
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
			// Tests that vehicle.requiresService of two services one at 100 and 200 and one no rent journey, 1 day daily journey and one perKm of 100km journey is true
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