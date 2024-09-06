﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        using ProductShopContext context = new ProductShopContext();

        // Problem 01
        //string userText = File.ReadAllText("../../../Datasets/users.json");
        //Console.WriteLine(ImportUsers(context, userText));

        // Problem 02
        //string productText = File.ReadAllText("../../../Datasets/products.json");
        //Console.WriteLine(ImportProducts(context, productText));

        // Problem 03
        //string categoriesText = File.ReadAllText("../../../Datasets/categories.json");
        //Console.WriteLine(ImportCategories(context, categoriesText));

        // Problem 04
        //string categoriesProductsText = File.ReadAllText("../../../Datasets/categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(context, categoriesProductsText));

        // Problem 06
        //Console.WriteLine(GetSoldProducts(context));

        // Problem 07
        //Console.WriteLine(GetCategoriesByProductsCount(context));

        // Problem 08
        Console.WriteLine(GetUsersWithProducts(context));
    }

    // Problem 01
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        var users = JsonConvert.DeserializeObject<List<User>>(inputJson);

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }

    // Problem 02
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

        context.Products.AddRange(products);
        context.SaveChanges();

        return $"Successfully imported {products.Count}";
    }

    // Problem 03
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

        categories.RemoveAll(c => c.Name == null);

        context.Categories.AddRange(categories);
        context.SaveChanges();

        return $"Successfully imported {categories.Count}";
    }

    // Problem 04
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        var categoriesProducts = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

        context.CategoriesProducts.AddRange(categoriesProducts);
        context.SaveChanges();

        return $"Successfully imported {categoriesProducts.Count}";
    }

    // Problem 05
    public static string GetProductsInRange(ProductShopContext context)
    {
        var products = context.Products
            .Where(p => p.Price >= 500 && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .Select(p => new ExportProductDto
            {
                Name = p.Name,
                Price = p.Price,
                Seller = $"{p.Seller.FirstName} {p.Seller.LastName}",
            })
            .ToList();

        var settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        return JsonConvert.SerializeObject(products, settings);
    }

    // Problem 06
    public static string GetSoldProducts(ProductShopContext context)
    {
        //var usersWithSoldProducts = context.Users
        //    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
        //    .Select(u => new
        //    {
        //        u.FirstName,
        //        u.LastName,
        //        SoldProducts = u.ProductsSold.Select(p => new
        //        {
        //            p.Name,
        //            p.Price,
        //            BuyerFirstName = p.Buyer.FirstName,
        //            BuyerLastName = p.Buyer.LastName,
        //        }),
        //    })
        //    .OrderBy(u => u.LastName)
        //    .ThenBy(u => u.FirstName)
        //    .ToList();

        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        var soldProducts = context.Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
            .Select(u => new SellerWithProductsDto()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                SoldProducts = u.ProductsSold.Select(p => new SoldProductsDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFirstName = p.Buyer.FirstName,
                    BuyerLastName = p.Buyer.LastName,
                })
            })
            .OrderBy(u => u.LastName)
            .ThenBy(u => u.FirstName)
            .ToList();

        return JsonConvert.SerializeObject(soldProducts, settings);
    }

    // Problem 07
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        var categoriesByProductsCount = context.Categories
            .Select(c => new
            {
                Category = c.Name,
                ProductsCount = c.CategoriesProducts.Count,
                AveragePrice = c.CategoriesProducts
                    .Average(cp => cp.Product.Price)
                    .ToString("f2"),
                TotalRevenue = c.CategoriesProducts
                    .Sum(cp => cp.Product.Price)
                    .ToString("f2"),
            })
            .OrderByDescending(c => c.ProductsCount)
            .ToList();

        return JsonConvert.SerializeObject(categoriesByProductsCount, settings);
    }

    // Problem 08
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        var settings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Formatting = Formatting.Indented,
        };

        var usersWithProducts = context
            .Users
            .Where(u => u.ProductsSold.Any(p => p.BuyerId != null && p.Price != null))
            .Select(u => new
            {
                u.FirstName,
                u.LastName,
                u.Age,
                SoldProducts = u.ProductsSold
                    .Where(p => p.BuyerId != null && p.Price != null)
                    .Select(p => new
                    {
                        p.Name,
                        p.Price,
                    }).ToArray(),
                })
            .OrderByDescending(u => u.SoldProducts.Count())
            .ToArray();

        var output = new
        {
            UsersCount = usersWithProducts.Length,
            Users = usersWithProducts
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Length,
                        Products = u.SoldProducts
                    }
                })
        };

        return JsonConvert.SerializeObject(output, settings);
    }
}