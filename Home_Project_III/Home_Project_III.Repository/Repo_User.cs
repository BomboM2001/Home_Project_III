using Home_Project_III.Data;
using Home_Project_III.Models;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace Home_Project_III.Repository
{
    // lack of interface AbRepo
    public class Repo_User : IUserRepository
    {
        ModelDbContext ctx;
        public Repo_User(ModelDbContext context)
        {
            this.ctx = context;
        }

        // CRUD Methods
        public void Create(string json)
        {
            UserInformation jUser = JsonConvert.DeserializeObject<UserInformation>(json);
            if (JsonConvert.DeserializeObject<UserInformation>(json).Full_Name == null)
            {
                throw new MissingNameException();
            }
            else if (JsonConvert.DeserializeObject<UserInformation>(json).Email == null)
            {
                throw new MissingEmailException();
            }
            ctx.Users.Attach(jUser);
            ctx.SaveChanges();
            Console.WriteLine($"User {jUser.UserID} added!");
        }

        public void Delete(int userId)
        {
            
        }

        public UserInformation Read(int userID)
        {
            var us = from x in ctx.Users
                     where x.UserID.Equals(userID)
                     select x;

            UserInformation ri = us.First();
            Console.WriteLine($"User {userID} read!");

            return ri;
        }

        public IQueryable<UserInformation> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(string json, int userId)
        {
            throw new NotImplementedException();
        }
    }

    public class MissingNameException : Exception
    {
        public MissingNameException()
        {
            Console.WriteLine("Error: No name specified!");
        }
    }

    public class MissingEmailException : Exception
    {
        public MissingEmailException()
        {
            Console.WriteLine("Error: No email provided!");
        }
    }
}
