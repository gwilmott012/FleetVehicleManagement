namespace FleetVehicleManagement.Entities
{
    public class Journey
    {
        public enum Rental
        {
            Daily,
            PerKM,
            None
        }

        public Rental RentalType  { get; set; }
        public int? NumberDays { get; set; }
        public int KmsTravelled { get; set; }

        public Journey()
        {

        }

        public Journey(Rental _RentalType, int? _NumberDays, int _KmsTravelled)
        {
            RentalType = _RentalType;
            NumberDays = _NumberDays;
            KmsTravelled = _KmsTravelled;
        }

		// if rental type is daily returns as an integer the number of days * the rental cost per day
		// otherwise if rental type is perKm returns kilometers travelled * the rental cost per kilometer
		public double GetRevenue()
        {
            if (RentalType==Rental.Daily)
            {
                return (int)NumberDays * Constants.Constants.rentalCostPerDay;
            }
            else if (RentalType==Rental.PerKM)
            {
                return KmsTravelled * Constants.Constants.rentalCostPerKm; 
            }
            return 0;
        }

    }
}
