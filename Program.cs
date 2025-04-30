using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Principal;
using static Program;

class Program
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    
    public class PremiumUser : User
    {   
        public string Role { get; set ; }
        public int Balance { get; set; }
    }
    public class Admin : PremiumUser
    {
        public string Role { get; set ; }
        public string Speciality { get; set ; }

    }
    static void Main(string[] args)
    {
        string filePath = "user_types.json";

        string jsonResponse = File.ReadAllText(filePath);

        var nuskaityti_users = JsonConvert.DeserializeObject<List<dynamic>>(jsonResponse);
        
        List<Admin> admins = new List<Admin>();
        List<User> users = new List<User>();
        List<PremiumUser> premiumUsers = new List<PremiumUser>();
        foreach (var user in nuskaityti_users)
        {
            if (user.Role == "Admin")
            {
                admins.Add(new Admin
                {
                    Name = user.Name,
                    Age = user.Age,
                    City = user.City,
                    Role = user.Role,
                    Speciality = user.Speciality
                });
            }else if(user.Role == "PremiumUser"){
                premiumUsers.Add(new PremiumUser
                {
                    Name =user.Name,
                    Age = user.Age,
                    City = user.City,
                    Role = user.Role,
                    Balance = user.Balance
                }) ;
            }
            else
            {
                users.Add(new User
                {
                    Name = user.Name,
                    Age = user.Age,
                    City = user.City
                });
            }
        }

        foreach (User user in users)
        {
            Console.WriteLine($"Name: {user.Name}");
            Console.WriteLine($"Age: {user.Age}");
            Console.WriteLine($"City: {user.City} \n");
        }
        foreach (Admin admin in admins)
        {
            Console.WriteLine($"Name: {admin.Name}");
            Console.WriteLine($"Age: {admin.Age}");
            Console.WriteLine($"City: {admin.City}");
            Console.WriteLine($"Role: {admin.Role}");
            Console.WriteLine($"Speciality: {admin.Speciality} \n");

        }
        foreach (PremiumUser premiumUser in premiumUsers)
        {
            Console.WriteLine($"Name: {premiumUser.Name}");
            Console.WriteLine($"Age: {premiumUser.Age}");
            Console.WriteLine($"City: {premiumUser.City}");
            Console.WriteLine($"Role: {premiumUser.Role}");
            Console.WriteLine($"Balance: {premiumUser.Balance} \n");
        }


    }
}