namespace CabInvoiceGenerator
{
    public class CustomCabInvoiceExceptions : Exception
    {
        public enum CustomExceptions
        {
            INVALID_DISTANCE_EXCEPTION,
            INVALID_TIME_EXCEPTION
        }

        public CustomExceptions Ex;

        public CustomCabInvoiceExceptions(CustomExceptions ex, string message) : base(message)
        {
            Ex = ex;
        }
    }
}