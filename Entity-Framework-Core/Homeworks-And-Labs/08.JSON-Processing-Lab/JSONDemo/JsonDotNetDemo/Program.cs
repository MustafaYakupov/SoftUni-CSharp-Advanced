using JsonDotNetDemo;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

var person = new Person()
{
    FullName = "Petar Petrov",
    Age = 25,
    Height = 185,
    Weigth = 83.7,
};

DefaultContractResolver contractResolver = new DefaultContractResolver()
{
    NamingStrategy = new CamelCaseNamingStrategy(),
};

var settings = new JsonSerializerSettings()
{
    ContractResolver = contractResolver,
};

string data = JsonConvert.SerializeObject(person); // Converts from Person to JSON 

Console.WriteLine(data);

Person? person1 = JsonConvert.DeserializeObject<Person>(data);// Converts from JSON to Person

Console.WriteLine($"{person1.FullName} is {person.Age} years old and is {person1.Height} cm high!");