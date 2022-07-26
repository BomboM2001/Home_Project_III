using Home_Project_III.Models;
using Home_Project_III.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Logic
{
    public class Logic_Run : IRunLogic
    {
        Repo_User userRepo;
        Repo_Run runRepo;
        Repo_Password passRepo;
        public Logic_Run(IUserLogic user, IRunLogic run, IPassLogic pass)
        {
            this.userRepo = (Repo_User)user;
            this.runRepo = (Repo_Run)run;
            this.passRepo = (Repo_Password)pass;
        }
        
        // CRUD Methods
        public void Create(string json)
        {
            runRepo.Create(json);
        }

        public void Delete(int runID)
        {
            runRepo.Delete(runID);
        }

        public RunInformation Read(int runID)
        {
            return runRepo.Read(runID);
        }

        public void Update(string json, int runID)
        {
            runRepo.Update(json, runID);
        }
        public IQueryable<RunInformation> ReadAll()
        {
            return runRepo.ReadAll();
        }

        // Non-CRUD methods
        public IEnumerable<int> GetRunIDOfPremiumUsers()
        {
            List<int> lista = new List<int>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.UserID
                      where u.Premium.Equals(true)
                      select r.RunID;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetTimeOfPremiumCompetitors()
        {
            List<string> lista = new List<string>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.UserID
                      where (r.IsCompetition.Equals(true) && u.Premium.Equals(true))
                      select r.Time;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<int> GetRunIDOfLongDistanceJuniorRunners()
        {
            List<int> lista = new List<int>();

            var sue = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where u.Age < 18 && r.Distance > 30
                      select r.RunID;


            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetLocationOfChonkers()
        {
            List<string> lista = new List<string>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.UserID
                      where u.Weight > 90 && u.Height < 170
                      select r.Location;


            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
        public IEnumerable<string> GetLocationOfJuniorPremiumUsers()
        {
            List<string> lista = new List<string>();

            var sue = from r in runRepo.ReadAll()
                      join u in userRepo.ReadAll()
                      on r.UserID equals u.UserID
                      where (u.Age < 18 && u.Premium.Equals(true))
                      select r.Location;

            foreach (var item in sue)
            {
                lista.Add(item);
            }

            return lista;
        }
    }
}
