namespace Cadastre.DataProcessor;

using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Cadastre.DataProcessor.ImportDtos;
using Invoices.Utilities;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

public class Deserializer
{
    private const string ErrorMessage =
        "Invalid Data!";
    private const string SuccessfullyImportedDistrict =
        "Successfully imported district - {0} with {1} properties.";
    private const string SuccessfullyImportedCitizen =
        "Succefully imported citizen - {0} {1} with {2} properties.";

    public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
    {
        // Add postalCode regex and range
        // Add Property Area not negative range

        StringBuilder sb = new StringBuilder();

        XmlHelper xmlHelper = new XmlHelper();
        const string xmlRoot = "Districts";

        ICollection<District> districtsToImport = new List<District>();

        ImportDistrictsDto[] deserializedDistricts = xmlHelper.Deserialize<ImportDistrictsDto[]>(xmlDocument, xmlRoot);

        foreach (var districtDto in deserializedDistricts)
        {
            if (!IsValid(districtDto))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            ICollection<Property> propertiesToImport = new List<Property>();

            if (dbContext.Districts.Any(d => d.Name == districtDto.Name))
            {
                sb.AppendLine(ErrorMessage);
                continue;
            }

            District newDistrict = new District()
            {
                Name = districtDto.Name,
                Region = (Region)Enum.Parse(typeof(Region), districtDto.Region),
                PostalCode = districtDto.PostalCode
            };

            foreach (var propertyDto in districtDto.Properties)
            {
                if (!IsValid(propertyDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime validDate = DateTime
                    .ParseExact(propertyDto.DateOfAcquisition, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture, 
                    DateTimeStyles.None);

                if (dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDto.PropertyIdentifier) 
                    || newDistrict.Properties.Any(dp => dp.PropertyIdentifier == propertyDto.PropertyIdentifier))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Properties.Any(p => p.Address == propertyDto.Address) 
                    || newDistrict.Properties.Any(dp => dp.Address == propertyDto.Address))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Property newProperty = new Property()
                {
                    PropertyIdentifier = propertyDto.PropertyIdentifier,
                    Area = propertyDto.Area,
                    Details = propertyDto.Details,
                    Address = propertyDto.Address,
                    DateOfAcquisition = validDate,
                };

                propertiesToImport.Add(newProperty);
            }

            newDistrict.Properties = propertiesToImport;

            districtsToImport.Add(newDistrict);
            sb.AppendLine(String.Format(SuccessfullyImportedDistrict, newDistrict.Name, propertiesToImport.Count));
        }

        dbContext.Districts.AddRange(districtsToImport);
        dbContext.SaveChanges();

        return sb.ToString().Trim();
    }

    public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
    {
        throw new NotImplementedException();
    }

    private static bool IsValid(object dto)
    {
        var validationContext = new ValidationContext(dto);
        var validationResult = new List<ValidationResult>();

        return Validator.TryValidateObject(dto, validationContext, validationResult, true);
    }
}
