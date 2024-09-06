using Invoices.Utilities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor;

public class Deserializer
{
    private const string ErrorMessage = "Invalid data format!";
    private const string DuplicationDataMessage = "Error! Data duplicated.";
    private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
    private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

    public static string ImportCustomers(TravelAgencyContext context, string xmlString)
    {
        StringBuilder sb = new StringBuilder();

        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Customers";

        ICollection<Customer> customersToImport = new List<Customer>();

        ImportCustomerDto[] deserializedCustomers = xmlHelper.Deserialize<ImportCustomerDto[]>(xmlString, xmlRoot);

        foreach (var customerDto in deserializedCustomers)
        {
            if (!IsValid(customerDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            if (context.Customers.Any(c => c.FullName == customerDto.FullName) 
                || customersToImport.Any(c => c.FullName == customerDto.FullName)
                || context.Customers.Any(c => c.Email == customerDto.Email) 
                || customersToImport.Any(c => c.Email == customerDto.Email)
                || context.Customers.Any(c => c.PhoneNumber == customerDto.PhoneNumber) 
                || customersToImport.Any(c => c.PhoneNumber == customerDto.PhoneNumber))
            {
                sb.AppendLine(DuplicationDataMessage);
                continue;
            }

            Customer newCustomer = new Customer()
            {
                FullName = customerDto.FullName,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
            };

            customersToImport.Add(newCustomer);
            sb.AppendLine(String.Format(SuccessfullyImportedCustomer, newCustomer.FullName));
        }

        context.Customers.AddRange(customersToImport);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportBookings(TravelAgencyContext context, string jsonString)
    {
        StringBuilder sb = new StringBuilder();

        ICollection<Booking> bookingsToImport = new List<Booking>();

        ImportBookingDto[] deserializedBookings = JsonConvert.DeserializeObject<ImportBookingDto[]>(jsonString)!;

        foreach (var bookingDto in deserializedBookings)
        {
            if (!IsValid(bookingDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            bool isBookingDateValid = DateTime
                .TryParseExact(bookingDto.BookingDate, 
                "yyyy-MM-dd", 
                CultureInfo.InvariantCulture, 
                DateTimeStyles.None, 
                out DateTime validBookingDate); // Parsed into issueDate

            if (isBookingDateValid == false)
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            Booking booking = new Booking()
            {
                BookingDate = validBookingDate,
            };

            Customer customer = context.Customers
                .First(c => c.FullName == bookingDto.CustomerName);

            TourPackage tourPackage = context.TourPackages
                .First(p => p.PackageName == bookingDto.TourPackageName);

            booking.Customer = customer;

            booking.TourPackage = tourPackage;

            bookingsToImport.Add(booking);
            sb.AppendLine(string.Format(SuccessfullyImportedBooking, booking.TourPackage.PackageName, booking.BookingDate.ToString("yyyy-MM-dd")));
        }

        context.Bookings.AddRange(bookingsToImport);
        context.SaveChanges();

        return sb.ToString().Trim();
    }

    public static bool IsValid(object dto)
    {
        var validateContext = new ValidationContext(dto);
        var validationResults = new List<ValidationResult>();

        bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

        foreach (var validationResult in validationResults)
        {
            string currValidationMessage = validationResult.ErrorMessage;
        }

        return isValid;
    }
}
