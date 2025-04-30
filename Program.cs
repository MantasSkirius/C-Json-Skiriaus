using Newtonsoft.Json;
using System;
using System.IO;

class Program
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    static void Main(string[] args)
    {
        string filePath = "user.json";

        string jsonResponse = File.ReadAllText(filePath);

        List<User> users = JsonConvert.DeserializeObject<List<User>>(jsonResponse);
        foreach (User user in users)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City}");
        }
        
    }
}