namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        public static double CalculateFare(RideDetials ride)
        {
            double totalFare;

            if (ride.Distance <= 0)
                throw new CustomCabInvoiceExceptions(CustomCabInvoiceExceptions.CustomExceptions.INVALID_DISTANCE_EXCEPTION, "Distance must have a value greater than zero."); // create custom exception class and throw a custom exception with userfriendly message
            else if (ride.Time <= 0)
                throw new CustomCabInvoiceExceptions(CustomCabInvoiceExceptions.CustomExceptions.INVALID_TIME_EXCEPTION, "Time must have a value that is greater than zero.");
            else
            {
                totalFare = ride.Distance * ride.COST_PER_KM + ride.Time * ride.COST_PER_MIN;
            }

            return Math.Max(totalFare, ride.MINIMUM_FARE);
        }

        public static InvoiceSummary CalculateFare(RideDetials[] rideDetials)
        {
            double totalFare = 0;

            foreach(RideDetials rideDetial in rideDetials)
            {
                totalFare += CalculateFare(rideDetial);
            }
            return new InvoiceSummary(totalFare,rideDetials.Length);
        }

        public static InvoiceSummary CalculateFareForUser(RideDetials[] rideDetials, int userId)
        {
            double totalFare = 0;

            foreach(RideDetials rideDetail in rideDetials)
            {
                if (rideDetail.UserId == userId)
                    totalFare += CalculateFare(rideDetail);
            }

            return new InvoiceSummary(totalFare, rideDetials.Count(r => r.UserId == userId));
        }
    }
}