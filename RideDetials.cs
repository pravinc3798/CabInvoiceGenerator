namespace CabInvoiceGenerator
{
    public class RideDetials
    {
        public readonly int MINIMUM_FARE; // readonly field can be updated in constructor
        public readonly int COST_PER_KM;
        public readonly int COST_PER_MIN;
        public readonly int UserId;
        public double Distance;
        public int Time;
        public RideType RideType;

        public RideDetials(int userId, double distance, int time, RideType rideType)
        {
            UserId = userId;
            Distance = distance;
            Time = time;
            RideType = rideType;

            if (rideType == RideType.NORMAL)
            {
                MINIMUM_FARE = 5;
                COST_PER_KM = 10;
                COST_PER_MIN = 1;
            }
            else
            {
                MINIMUM_FARE = 20;
                COST_PER_KM = 15;
                COST_PER_MIN = 2;
            }
        }
    }
}