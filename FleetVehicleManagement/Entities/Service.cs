namespace FleetVehicleManagement.Entities
{
    public class Service
    {

        public int Odometer { get; set; }

        public Service()
        {

        }

        public Service( int _Odometer)
        {
            Odometer = _Odometer;
        }
    }
}
