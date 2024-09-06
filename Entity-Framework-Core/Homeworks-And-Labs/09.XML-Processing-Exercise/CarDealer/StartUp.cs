using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext context = new CarDealerContext();

        // Problem 09
        //string suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
        //Console.WriteLine(ImportSuppliers(context, suppliersXml));

        // Problem 10
        //string suppliersXml = File.ReadAllText("../../../Datasets/parts.xml");
        //Console.WriteLine(ImportParts(context, suppliersXml));

        // Problem 11
        //string suppliersXml = File.ReadAllText("../../../Datasets/cars.xml");
        //Console.WriteLine(ImportCars(context, suppliersXml));

        // Problem 12
        //string suppliersXml = File.ReadAllText("../../../Datasets/customers.xml");
        //Console.WriteLine(ImportCustomers(context, suppliersXml));

        // Problem 13
        //string suppliersXml = File.ReadAllText("../../../Datasets/sales.xml");
        //Console.WriteLine(ImportSales(context, suppliersXml));

        // Problem 14
        //Console.WriteLine(GetCarsWithDistance(context));

        // Problem 15
        //Console.WriteLine(GetCarsFromMakeBmw(context));

        // Problem 16
        //Console.WriteLine(GetLocalSuppliers(context));

        // Problem 17
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        // Problem 18
        //Console.WriteLine(GetTotalSalesByCustomer(context));

        // Problem 19
        Console.WriteLine(GetSalesWithAppliedDiscount(context));
    }

    // Xml Serializer Method
    private static string SerializeToXml<T>(T dto, string xmlRootAttribute, bool omitDeclaration = false)
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), new XmlRootAttribute(xmlRootAttribute));
        StringBuilder stringBuilder = new StringBuilder();

        XmlWriterSettings settings = new XmlWriterSettings()
        {
            OmitXmlDeclaration = omitDeclaration,
            Encoding = new UTF8Encoding(false),
            Indent = true,
        };

        using StringWriter stringWriter = new StringWriter(stringBuilder, CultureInfo.InvariantCulture);

        using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
        {
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add(string.Empty, string.Empty);

            try
            {
                xmlSerializer.Serialize(xmlWriter, dto, xmlSerializerNamespaces);
            }
            catch (Exception)
            {

                throw;
            }
        }

        return stringBuilder.ToString();
    }

    // Problem 09
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDto[]),
            new XmlRootAttribute("Suppliers"));

        SupplierImportDto[] importDtos = (SupplierImportDto[])xmlSerializer.Deserialize(reader);

        Supplier[] suppliers = importDtos
            .Select(dto => new Supplier()
            {
                Name = dto.Name,
                IsImporter = dto.IsImporter,
            })
            .ToArray();

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}";
    }

    // Problem 10
    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartsImportDto[]),
            new XmlRootAttribute("Parts"));

        PartsImportDto[] importDtos = (PartsImportDto[])xmlSerializer.Deserialize(reader);

        var supplierIds = context.Suppliers
            .Select(s => s.Id)
            .ToArray();

        var partsWithValidSuppliers = importDtos
            .Where(p => supplierIds.Contains(p.SupplierId))
            .ToArray();

        Part[] parts = partsWithValidSuppliers
            .Select(dto => new Part()
            {
                Name = dto.Name,
                Price = dto.Price,
                Quantity = dto.Quantity,
                SupplierId = dto.SupplierId,
            })
            .ToArray();

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Length}";
    }

    // Problem 11
    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarsImportDto[]), new XmlRootAttribute("Cars"));

        CarsImportDto[] importDtos = (CarsImportDto[])xmlSerializer.Deserialize(reader);

        List<Car> cars = new List<Car>();

        foreach (var dto in importDtos)
        {
            Car car = new Car()
            {
                Make = dto.Make,
                Model = dto.Model,
                TraveledDistance = dto.TravelledDistance,
            };

            int[] carPartsIds = dto.PartIds
                .Select(p => p.Id)
                .Distinct()
                .ToArray();

            var carParts = new List<PartCar>();

            foreach (var id in carPartsIds)
            {
                carParts.Add(new PartCar()
                {
                    Car = car,
                    PartId = id,
                });
            }

            car.PartsCars = carParts;
            cars.Add(car);
        }

        context.AddRange(cars);

        context.SaveChanges();

        return $"Successfully imported {cars.Count}";
    }

    // Problem 12
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomersImportDto[]), new XmlRootAttribute("Customers"));

        CustomersImportDto[] importDtos = (CustomersImportDto[])xmlSerializer.Deserialize(reader);

        Customer[] customers = importDtos.
            Select(dto => new Customer()
            {
                Name = dto.Name,
                BirthDate = dto.BirthDate,
                IsYoungDriver = dto.IsYoungDriver,
            })
            .ToArray();

        context.AddRange(customers);

        context.SaveChanges();

        return $"Successfully imported {customers.Length}";
    }

    // Problem 13
    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SalesImportDto[]),
            new XmlRootAttribute("Sales"));

        SalesImportDto[] importDtos = (SalesImportDto[])xmlSerializer.Deserialize(reader);

        int[] validCarsIds = context.Cars
            .Select(c => c.Id)
            .ToArray();

        Sale[] sales = importDtos
            .Where(dto => validCarsIds.Contains(dto.CarId))
            .Select(dto => new Sale()
            {
                Discount = dto.Discount,
                CarId = dto.CarId,
                CustomerId = dto.CustomerId,
            })
            .ToArray();

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Length}";
    }

    // Problem 14
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        var cars = context.Cars
                .Where(c => c.TraveledDistance > 2000000)
                .Select(c => new CarDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TraveledDistance = c.TraveledDistance
                })
                .OrderBy(c => c.Make)
                .ThenBy(c => c.Model)
                .Take(10)
                .ToArray();

        //using var writer = new StringWriter();

        //var ns = new XmlSerializerNamespaces();
        //ns.Add("", "");

        //var serializer = new XmlSerializer(typeof(CarDistanceDto[]), new XmlRootAttribute("cars"));
        //serializer.Serialize(writer, cars, ns);

        //var carsXml = writer.GetStringBuilder();

        //return carsXml.ToString().TrimEnd();

        return SerializeToXml(cars, "cars");
    }

    // Problem 15
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var bmws = context.Cars
            .Select(c => new BmwExportDto()
            {
                Id = c.Id,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

        return SerializeToXml(bmws, "cars");
    }

    // Problem 16
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new LocalSupplierExportDto()
            {
                Id = s.Id,
                Name = s.Name,
                PartsCount = s.Parts.Count
            })
            .ToArray();

        return SerializeToXml(localSuppliers, "suppliers");
    }

    // Problem 17
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var carsWithParts = context.Cars
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .Select(c => new CarWithPartsDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars
                    .OrderByDescending(p => p.Part.Price)
                    .Select(pc => new PartsForCarsDto()
                    {
                        Name = pc.Part.Name,
                        Price = pc.Part.Price,
                    })
                    .ToArray()
            })
            .ToArray();

        return SerializeToXml(carsWithParts, "cars");
    }

    // Problem 18
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var temp = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count,
                SalesInfo = c.Sales
                    .Select(s => new
                    {
                        Prices = c.IsYoungDriver
                        ? s.Car.PartsCars.Sum(pc => Math.Round((double)pc.Part.Price * 0.95, 2))
                        : s.Car.PartsCars.Sum(pc => (double)pc.Part.Price)
                    })
                    .ToArray()
            })
            .ToArray();

        var customerSalesInfo = temp
            .OrderByDescending(x => x.SalesInfo.Sum(y => y.Prices))
            .Select(a => new CustomerExportDto()
            {
                FullName = a.FullName,
                CarsBought = a.BoughtCars,
                MoneySpent = a.SalesInfo.Sum(b => (decimal)b.Prices)
            })
            .ToArray();

        return SerializeToXml(customerSalesInfo, "customers");
    }

    // Problem 19
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
                .Select(s => new SaleWithDiscountDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TraveledDistance = s.Car.TraveledDistance
                    },
                    Discount = (int)s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartsCars
                        .Sum(p => p.Part.Price),
                    PriceWithDiscount = s.Car.PartsCars.Sum(p => p.Part.Price)
                        - (s.Car.PartsCars.Sum(p => p.Part.Price) * s.Discount / 100)
                })
                .ToArray();

        return SerializeToXml(sales, "sales");
    }
}