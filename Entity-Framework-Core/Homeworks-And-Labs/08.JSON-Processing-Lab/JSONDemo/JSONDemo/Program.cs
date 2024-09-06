using JSONDemo;
using System.Text.Json;

var person = new Person()
{
    FullName = "Petar Petrov",
    Age = 25,
    Height = 185,
    Weigth = 83.7,
};

var options = new JsonSerializerOptions()
{
    WriteIndented = true,
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
};

string data = JsonSerializer.Serialize(person, options); // Converts from Person to JSON 

Console.WriteLine(data);

Person? person1 = JsonSerializer.Deserialize<Person>(data, options); // Converts from JSON to Person

Console.WriteLine($"{person1.FullName} is {person.Age} years old and is {person1.Height} cm high!");