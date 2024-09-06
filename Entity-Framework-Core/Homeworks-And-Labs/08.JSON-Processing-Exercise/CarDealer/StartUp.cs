using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        using CarDealerContext context = new CarDealerContext();

        // Problem 09
        //string suppliersString = File.ReadAllText("../../../Datasets/suppliers.json");
        //Console.WriteLine(ImportSuppliers(context, suppliersString));

        // problem 10
        //string partsString = File.ReadAllText("../../../Datasets/parts.json");
        //Console.WriteLine(ImportParts(context, partsString));

        // Problem 11
        //string carsString = File.ReadAllText("../../../Datasets/cars.json");
        //Console.WriteLine(ImportCars(context, carsString));

        // Problem 12
        //string customersString = File.ReadAllText("../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(context, customersString));

        // Problem 13
        //string salesString = File.ReadAllText("../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(context, salesString));

        // Problem 14
        //Console.WriteLine(GetOrderedCustomers(context));

        // Probolem 15
        //Console.WriteLine(GetCarsFromMakeToyota(context));

        // Problem 16
        //Console.WriteLine(GetLocalSuppliers(context));

        // Problem 17
        //Console.WriteLine(GetCarsWithTheirListOfParts(context));

        // Problem 18
        Console.WriteLine(GetTotalSalesByCustomer(context));

        // Problem 19
        //Console.WriteLine(GetSalesWithAppliedDiscount(context));
    }

    // problem 09
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        List<Supplier> suppliers = JsonConvert.DeserializeObject<List<Supplier>>(inputJson);

        context.Suppliers.AddRange(suppliers);

        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    // Problem 10
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        List<Part> parts = JsonConvert.DeserializeObject<List<Part>>(inputJson);

        var validSupplierIds = context.Suppliers
            .Select(s => s.Id)
            .ToArray();

        var partsWithValidSupplierIds = parts
            .Where(p => validSupplierIds.Contains(p.SupplierId));

        context.Parts.AddRange(partsWithValidSupplierIds);

        context.SaveChanges();

        return $"Successfully imported {partsWithValidSupplierIds.Count()}.";
    }

    // Problem 11
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        var carsDtos = JsonConvert.DeserializeObject<List<ImportCarDto>>(inputJson);

        var cars = new HashSet<Car>();
        var partsCars = new HashSet<PartCar>();

        foreach (var carDto in carsDtos)
        {
            var newCar = new Car()
            {
                Make = carDto.Make,
                Model = carDto.Model,
                TraveledDistance = carDto.TravelledDistance,
            };

            cars.Add(newCar);

            foreach (var partId in carDto.PartsId.Distinct())
            {
                partsCars.Add(new PartCar()
                {
                    Car = newCar,
                    PartId = partId,
                });
            }
        }

        context.Cars.AddRange(cars);
        context.PartsCars.AddRange(partsCars);

        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    // Problem 12
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        List<Customer> customers = JsonConvert.DeserializeObject<List<Customer>>(inputJson);

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }

    // Problem 13
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        List<Sale> sales = JsonConvert.DeserializeObject<List<Sale>>(inputJson);

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }

    // Problem 14
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            //ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        var orderedCustomers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .Select(c => new
            {
                c.Name,
                BirthDate = c.BirthDate.ToString("dd/MM/yyyy"),
                c.IsYoungDriver,
            })
            .ToArray();

        return JsonConvert.SerializeObject(orderedCustomers, settings);
    }

    // Problem 15
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };

        var toyotaCars = context.Cars
            .Where(c => c.Make.ToLower() == "toyota")
            .Select(c => new
            {
                c.Id,
                c.Make,
                c.Model,
                c.TraveledDistance,
            })
            .OrderBy(c => c.Model)
            .ThenByDescending(c => c.TraveledDistance)
            .ToArray();

        return JsonConvert.SerializeObject(toyotaCars, settings);
    }

    // Problem 16
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };

        var suppliersNotImportingCarsFromAbroad = context.Suppliers
            .Where(s => s.IsImporter == false)
            .Select(s => new
            {
                s.Id,
                s.Name,
                PartsCount = s.Parts.Count,
            })
            .ToArray();

        var suppliersToJson = JsonConvert.SerializeObject(suppliersNotImportingCarsFromAbroad, settings);

        return suppliersToJson;
    }

    // Problem 17
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
        };

        var cars = context.Cars
                 .Select(c => new CarPartsDto
                 {
                     Car = new ExportCarDto
                     {
                         Make = c.Make,
                         Model = c.Model,
                         TravelledDistance = c.TraveledDistance
                     },
                     Parts = c.PartsCars
                         .Select(p => new ExportPartDto
                         {
                             Name = p.Part.Name,
                             Price = $"{p.Part.Price:F2}"
                         })
                         .ToList()
                 })
                 .ToList();

        var carsToJson = JsonConvert.SerializeObject(cars, settings);

        return carsToJson;
    }

    // Problem 18
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        var customers = context.Customers
                .Where(c => c.Sales.Any(s => s.Car != null))
                .Select(c => new
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count(s => s.Car != null),
                    SpentMoney = c.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(p => p.Part.Price)
                })
                .OrderByDescending(c => c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

        var customersToJson = JsonConvert.SerializeObject(customers, settings);

        return customersToJson;
    }

    // Problem 19
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
                .Select(s => new 
                {
                    Car = new 
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TraveledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    Price = $"{s.Car.PartsCars.Sum(p => p.Part.Price):F2}",
                    PriceWithDiscount = $@"{s.Car.PartsCars.Sum(p => p.Part.Price)
                        - s.Car.PartsCars.Sum(p => p.Part.Price) * s.Discount / 100:F2}"
                })
                .Take(10)
                .ToList();

        var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

        return salesJson;
    }
}