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
    public class NegativeDistanceException : Exception
    {
        public NegativeDistanceException()
        {
            Console.WriteLine("Error: No name specified");
        }
    }
    public class MissingLocationException : Exception
    {
        public MissingLocationException()
        {
            Console.WriteLine("Error: No location provided");
        }
    }
    public class WrongUserIDException : Exception
    {
        public WrongUserIDException()
        {
            Console.WriteLine("Error: Wrong user id provided");
        }
    }
    public class Repo_Run : IRunRepository
    {
        ModelDbContext ctx;
        public Repo_Run(ModelDbContext context) 
        {
            this.ctx = context;
        }

        //CRUD Methods

        public void Create(string json)
        {

            RunInformation jRun = JsonConvert.DeserializeObject<RunInformation>(json);

            if (JsonConvert.DeserializeObject<RunInformation>(json).Distance < 0)
            {
                throw new NegativeDistanceException();
            }
            else if (JsonConvert.DeserializeObject<RunInformation>(json).Location == null)
            {
                throw new MissingLocationException();
            }
            else if (JsonConvert.DeserializeObject<RunInformation>(json).UserID < 0)
            {
                throw new WrongUserIDException();
            }

            ctx.Runs.Attach(jRun);
            ctx.SaveChanges();
            Console.WriteLine($"Run {jRun.RunID} created!");

        }
        public RunInformation Read(int runID)
        {
            var us = from x in ctx.Runs
                     where x.RunID.Equals(runID)
                     select x;

            RunInformation ri = us.First();

            Console.WriteLine($"Run {ri.RunID} read!");

            return ri;
        }
        public IQueryable<RunInformation> ReadAll()
        {
            var us = from x in ctx.Runs
                     select x;

            IQueryable<RunInformation> list = us.AsQueryable().Select(x => x);

            Console.WriteLine("All runs read!");

            return list;
        }
        public void Update(string json, int runID)
        {
            RunInformation jRun = JsonConvert.DeserializeObject<RunInformation>(json);

            if (JsonConvert.DeserializeObject<RunInformation>(json).Distance < 0)
            {
                throw new NegativeDistanceException();
            }
            else if (JsonConvert.DeserializeObject<RunInformation>(json).Location == null)
            {
                throw new MissingLocationException();
            }
            else if (JsonConvert.DeserializeObject<RunInformation>(json).UserID < 0)
            {
                throw new WrongUserIDException();
            }

            RunInformation oldRun = ctx.Runs
                .First(x => x.RunID.Equals(runID));

            ctx.Runs.Remove(oldRun);

            jRun.RunID = oldRun.RunID;
            jRun.userInfo = oldRun.userInfo;

            ctx.Add(jRun);
            ctx.SaveChanges();

            Console.WriteLine($"Run {jRun.RunID} added!");
        }
        public void Delete(int runID)
        {

            var us = from x in ctx.Runs
                     select x;

            foreach (var item in us)
            {
                if (item.RunID.Equals(runID))
                {
                    ctx.Remove(item);
                    Console.WriteLine($"Run {runID} deleted!");
                }
            }
            ctx.SaveChanges();
        }
    }
}
