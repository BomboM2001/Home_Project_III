﻿using Home_Project_III.Data;
using Home_Project_III.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Repository
{
    public class MissingPasswordException : Exception
    {
        public MissingPasswordException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingPhoneNumberException : Exception
    {
        public MissingPhoneNumberException()
        {
            Console.WriteLine("Error: No email provided");
        }
    }
    public class Repo_Password : IPassRepository
    {
        ModelDbContext ctx;
        public Repo_Password(ModelDbContext context) 
        {
            this.ctx = context;
        }

        //CRUD Methods
        public void Create(string json)
        {
            PasswordSecurity jPass = JsonConvert.DeserializeObject<PasswordSecurity>(json);

            if (JsonConvert.DeserializeObject<PasswordSecurity>(json).TotallySecuredVeryHashedPassword == null)
            {
                throw new MissingPasswordException();
            }
            else if (JsonConvert.DeserializeObject<PasswordSecurity>(json).RecoverPhoneNumber == null)
            {
                throw new MissingPhoneNumberException();
            }
            else if (JsonConvert.DeserializeObject<PasswordSecurity>(json).UserId < 1)
            {
                throw new WrongUserIDException();
            }

            ctx.Passwords.Attach(jPass);
            ctx.SaveChanges();
            Console.WriteLine($"Password {jPass.PassId} created!");

        }
        public PasswordSecurity Read(int userID)
        {

            var us = from x in ctx.Passwords
                     where x.UserId.Equals(userID)
                     select x;

            PasswordSecurity ri = us.First();

            Console.WriteLine($"Password {ri.PassId} read!");

            return ri;

        }
        public IQueryable<PasswordSecurity> ReadAll()
        {
            var us = from x in ctx.Passwords
                     select x;

            IQueryable<PasswordSecurity> list = us.AsQueryable().Select(x => x);

            Console.WriteLine("All passwords read!");

            return list;
        }
        public void Update(string json, int passID)
        {
            PasswordSecurity jPass = JsonConvert.DeserializeObject<PasswordSecurity>(json);

            if (JsonConvert.DeserializeObject<PasswordSecurity>(json).TotallySecuredVeryHashedPassword == null)
            {
                throw new MissingPasswordException();
            }
            else if (JsonConvert.DeserializeObject<PasswordSecurity>(json).RecoverPhoneNumber == null)
            {
                throw new MissingPhoneNumberException();
            }
            else if (JsonConvert.DeserializeObject<PasswordSecurity>(json).UserId < 1)
            {
                throw new WrongUserIDException();
            }

            PasswordSecurity oldPass = ctx.Passwords
                .First(x => x.PassId.Equals(passID));

            ctx.Passwords.Remove(oldPass);

            jPass.PassId = oldPass.PassId;
            jPass.UserInformation = oldPass.UserInformation;

            ctx.Passwords.Add(jPass);
            ctx.SaveChanges();

            Console.WriteLine($"Password {jPass.PassId} updated!");
        }
        public void Delete(int passId)
        {
            var us = from x in ctx.Passwords
                     select x;

            foreach (var item in us)
            {
                if (item.UserId.Equals(passId))
                {
                    ctx.Remove(item);
                    Console.WriteLine($"Password {passId} deleted!");
                }
            }
            ctx.SaveChanges();
        }


    }
}
