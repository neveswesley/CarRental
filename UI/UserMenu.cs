using Exercices.Entities;
using Exercices.Services;
using System.Globalization;

namespace Exercices.UI
{
    internal class UserMenu
    {

        public void CarMenu()
        {

            Console.WriteLine("Enter rental data");
            Console.Write("Car model: ");
            var model = Console.ReadLine();
            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            var start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            var finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            var pricePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter price per day: ");
            var pricePerDay = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            var carRental = new CarRental(start, finish, new Vehicle(model));

            var rentalService = new RentalService(pricePerHour, pricePerDay, new BrazilTaxService());

            rentalService.ProcessInvoice(carRental);

            Console.WriteLine("INVOICE: ");
            Console.WriteLine(carRental.Invoice);
        }

    }
}
