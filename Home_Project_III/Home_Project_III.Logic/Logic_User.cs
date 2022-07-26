using Home_Project_III.Models;
using Home_Project_III.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Logic
{
    public class Logic_User : IUserLogic
    {
        Repo_User userRepo;
        Repo_Run runRepo;
        Repo_Password passwordRepo;
        public Logic_User(IUserRepository user, IPassRepository pass, IRunRepository run)
        {
            this.userRepo = (Repo_User)user;
            this.runRepo = (Repo_Run)run;
            this.passwordRepo = (Repo_Password)pass;
        }

        // CRUD methods
        public void Create(string json)
        {
            userRepo.Create(json);
        }

        public void Delete(int userID)
        {
            userRepo.Delete(userID);
        }

        public UserInformation Read(int userID)
        {
            return userRepo.Read(userID);
        }

        public IQueryable<UserInformation> ReadAll()
        {
            return userRepo.ReadAll();
        }

        public void Update(string json, int userID)
        {
            userRepo.Update(json, userID);
        }


        // Non-CRUD methods
        public IEnumerable<string> GetAmericanUsersNames()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.Location.Contains("United States")
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }

        public IEnumerable<string> GetCompetitorsEmailAddress()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.IsCompetition.Equals(true)
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }
            return lista;
        }

        public IEnumerable<string> GetEmailOfWeakPasswordUsers()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join p in passwordRepo.ReadAll()
                      on u.UserID equals p.UserId
                      where p.TotallySecuredVeryHashedPassword.Length < 10
                      select u.Email;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }

        public IEnumerable<string> GetLongDistanceCompetitorsNames()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where r.Distance > 20
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }

        public IEnumerable<string> GetNameOfLongDistanceOldRunners()
        {
            List<string> lista = new List<string>();

            var oke = from u in userRepo.ReadAll()
                      join r in runRepo.ReadAll()
                      on u.UserID equals r.UserID
                      where u.Age > 40 && r.Distance > 20
                      select u.Full_Name;

            foreach (var item in oke)
            {
                lista.Add(item);
            }

            return lista;
        }

        
    }
}
