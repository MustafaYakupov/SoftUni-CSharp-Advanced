using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Globalization;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        using ProductShopContext context = new ProductShopContext();

        // Problem 01
        //string suppliersXml = File.ReadAllText("../../../Datasets/users.xml");
        //Console.WriteLine(ImportUsers(context, suppliersXml));

        // Problem 02
        //string suppliersXml = File.ReadAllText("../../../Datasets/products.xml");
        //Console.WriteLine(ImportProducts(context, suppliersXml));

        // Problem 03
        //string suppliersXml = File.ReadAllText("../../../Datasets/categories.xml");
        //Console.WriteLine(ImportCategories(context, suppliersXml));

        // Problem 04
        //string suppliersXml = File.ReadAllText("../../../Datasets/categories-products.xml");
        //Console.WriteLine(ImportCategoryProducts(context, suppliersXml));

        // Problem 05
        //Console.WriteLine(GetProductsInRange(context));

        // Problem 06
        //Console.WriteLine(GetSoldProducts(context));

        // Problem 07
        //Console.WriteLine(GetCategoriesByProductsCount(context));

        // Problem 08
        Console.WriteLine(GetUsersWithProducts(context));
    }

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

    // Problem 01
    public static string ImportUsers(ProductShopContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(UsersImportDto[]),
            new XmlRootAttribute("Users"));

        UsersImportDto[] importDtos = (UsersImportDto[])xmlSerializer.Deserialize(reader);

        User[] users = importDtos
            .Select(dto => new User()
            {
                FirstName = dto.Firstname,
                LastName = dto.LastName,
                Age = dto.Age,
            })
            .ToArray();

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Length}";
    }

    // Problem 02
    public static string ImportProducts(ProductShopContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ProductsImportDto[]), new XmlRootAttribute("Products"));

        ProductsImportDto[] importDtos = (ProductsImportDto[])xmlSerializer.Deserialize(reader);

        Product[] products = importDtos
            .Select(dto => new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                SellerId = dto.SellerId,
                BuyerId = dto.BuyerId,
            })
            .ToArray();

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Length}";
    }

    // Problem 03
    public static string ImportCategories(ProductShopContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesImportDto[]), new XmlRootAttribute("Categories"));

        CategoriesImportDto[] importDtos = (CategoriesImportDto[])xmlSerializer.Deserialize(reader);

        Category[] categories = importDtos
            .Where(c => c.Name != null)
            .Select(dto => new Category()
            {
                Name = dto.Name,
            })
            .ToArray();

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Length}";
    }

    // Problem 04
    public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
    {
        using StringReader reader = new StringReader(inputXml);

        XmlSerializer xmlSerializer = new XmlSerializer(typeof(CategoriesProductsImportDto[]), new XmlRootAttribute("CategoryProducts"));

        CategoriesProductsImportDto[] importDtos = (CategoriesProductsImportDto[])xmlSerializer.Deserialize(reader);

        int[] existingProductIds = context.Products
            .Select(p => p.Id)
            .ToArray();

        int[] existingCategoryIds = context.Categories
            .Select(c => c.Id)
            .ToArray();

        CategoryProduct[] categoriesProducts = importDtos
            .Where(cp => existingCategoryIds.Contains(cp.CategoryId) && existingProductIds.Contains(cp.ProductId))
            .Select(dto => new CategoryProduct()
            {
                CategoryId = dto.CategoryId,
                ProductId = dto.ProductId,
            })
            .ToArray();

        context.CategoryProducts.AddRange(categoriesProducts);
        context.SaveChanges();

        return $"Successfully imported {categoriesProducts.Length}";
    }

    // Problem 05
    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new ProductsInRangeExportDto()
            {
                Name = p.Name,
                Price = p.Price,
                Buyer = p.Buyer.FirstName + " " + p.Buyer.LastName,
            })
            .Take(10)
            .ToArray();

        return SerializeToXml(products, "Products");
    }

    // Problem 06
    public static string GetSoldProducts(ProductShopContext context)
    {
        var usersWithSoldProducts = context.Users
            .Where(u => u.ProductsSold.Any())
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .Select(u => new UsersWithSoldProductsExportDto()
            {
                FristName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.ProductsSold
                    .Select(p => new SoldProductsOfUsersDto()
                    {
                        Name = p.Name,
                        Price = p.Price,
                    })
                    .ToArray(),
            })
            .Take(5)
            .ToArray();

        return SerializeToXml(usersWithSoldProducts, "Users");
    }

    // Problem 07
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var categories = context.Categories
            .Select(c => new CategoriesByProductExportDTO()
            {
                Name = c.Name,
                Count = c.CategoryProducts.Count(),
                AveragePrice = c.CategoryProducts.Average(cp => cp.Product.Price),
                TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price),
            })
            .OrderByDescending(c => c.Count)
            .ThenBy(c => c.TotalRevenue)
            .ToArray();

        return SerializeToXml(categories, "Categories");
    }

    // Problem 08
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var users = context.Users
            .Where(u => u.ProductsSold.Any())
            .OrderByDescending(u => u.ProductsSold.Count())
            .Select(u => new UsersExportDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Age = u.Age,
                SoldProducts = new SoldProductExportDto()
                {
                    Count = u.ProductsSold.Count(),
                    Products = u.ProductsSold
                            .Select(p => new ProductsExportDto()
                            {
                                Name = p.Name,
                                Price = p.Price
                            })
                            .OrderByDescending(p => p.Price)
                            .ToArray()
                }
            })
            .Take(10)
            .ToArray();

        var usersAndProdutcs = new UserAndProductsExportDto()
        {
            Count = context.Users.Count(u => u.ProductsSold.Any()),
            Users = users,
        };

        return SerializeToXml(usersAndProdutcs, "Users");
    }
}