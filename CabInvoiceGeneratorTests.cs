using CabInvoiceGenerator;

namespace CabInvoiceGeneratorTestProject
{
    public class CabInvoiceGeneratorTests
    {
        [Test]
        [TestCase(1,5,5,55,RideType.NORMAL)]
        [TestCase(1,5,5,85,RideType.PREMIUM)]
        [TestCase(1,0.2, 1, 5, RideType.NORMAL)]
        [TestCase(1,0.2, 1, 20, RideType.PREMIUM)]
        [TestCase(1, 0, 5, 55, RideType.NORMAL)]
        [TestCase(1, 5, 0, 55, RideType.NORMAL)]
        public void Given_DistanceAndTime_Return_TotalFare(int userId, double distance, int time, double expected, RideType rT)
        {
            try
            {
                RideDetials rideDetials = new RideDetials(userId, distance, time, rT);
                double actual = InvoiceGenerator.CalculateFare(rideDetials);

                Assert.AreEqual(actual, expected);
            }
            catch (CustomCabInvoiceExceptions ex)
            {
                if (distance <= 0)
                    Assert.That(ex.Ex, Is.EqualTo(CustomCabInvoiceExceptions.CustomExceptions.INVALID_DISTANCE_EXCEPTION));
                else
                    Assert.That(ex.Ex, Is.EqualTo(CustomCabInvoiceExceptions.CustomExceptions.INVALID_TIME_EXCEPTION));
            }
        }

        [Test]
        public void Given_MultipleRide_Return_TotalFare()
        {
            RideDetials[] rideDetials = { new RideDetials(1,5, 2, RideType.NORMAL), new RideDetials(1,2, 3,RideType.PREMIUM) };

            InvoiceSummary expected = new InvoiceSummary(88,rideDetials.Length);
            InvoiceSummary actual = InvoiceGenerator.CalculateFare(rideDetials);

            //Assert.AreEqual(actual, expected);
            //expected.Equals(actual);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        [TestCase(1,88)]
        [TestCase(2,106)]
        public void Given_UserID_Return_InvoiceSummaryForThatUser(int userId, double expected)
        {
            RideDetials[] rideDetials = { new RideDetials(1, 5, 2, RideType.NORMAL), new RideDetials(1, 2, 3, RideType.PREMIUM), new RideDetials(2,6,8,RideType.PREMIUM) };

            InvoiceSummary actual = InvoiceGenerator.CalculateFareForUser(rideDetials, userId);

            Assert.AreEqual(actual.TotalFare, expected);
        }
    }
}