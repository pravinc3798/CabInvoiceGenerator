namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public double TotalFare;
        public int NumberOfRides;
        public double AverageFare;

        public InvoiceSummary(double totalFare, int numberOfRides)
        {
            TotalFare = totalFare;
            NumberOfRides = numberOfRides;
            AverageFare = totalFare / numberOfRides;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
                return false;

            if (obj is not InvoiceSummary)
                return false;

            InvoiceSummary other = (InvoiceSummary)obj;

            return NumberOfRides == other.NumberOfRides && TotalFare == other.TotalFare && AverageFare == other.AverageFare; 
        }
    }
}