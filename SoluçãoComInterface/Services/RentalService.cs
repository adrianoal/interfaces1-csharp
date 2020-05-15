using System;
using SoluçãoSemInterface.Entities;

namespace SoluçãoSemInterface.Services
{
    class RentalService
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService _TaxService;

        public RentalService(double pricePerHour, double pricePerDay, ITaxService taxService)
        {
            PricePerHour = pricePerHour;
            PricePerDay = pricePerDay;
            _TaxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental)
        {
            TimeSpan duraction = carRental.Finish.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if (duraction.TotalHours <= 12.0)
            {
                basicPayment = PricePerHour * Math.Ceiling(duraction.TotalHours);// Math.Ceiling --> arredonda p/ mais
            }
            else
            {
                basicPayment = PricePerDay * Math.Ceiling(duraction.TotalDays);
            }
            double tax = _TaxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment,tax);
        }      
    }
}
