using Home_Project_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Home_Project_III.Logic
{
    public interface IUserLogic
    {
        public void Create(string json);
        public void Delete(int userID);
        public UserInformation Read(int userID);
        public void Update(string json, int userID);
        public IQueryable<UserInformation> ReadAll();

        public IEnumerable<string> GetEmailOfWeakPasswordUsers();
        public IEnumerable<string> GetCompetitorsEmailAddress();
        public IEnumerable<string> GetAmericanUsersNames();
        public IEnumerable<string> GetLongDistanceCompetitorsNames();
        public IEnumerable<string> GetNameOfLongDistanceOldRunners();
    }
}
