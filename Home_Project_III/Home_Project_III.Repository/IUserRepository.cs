using Home_Project_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Repository
{
    public interface IUserRepository
    {
        public void Create(string json);
        public IQueryable<UserInformation> ReadAll();
        public UserInformation Read(int userID);
        public void Delete(int userId);
        public void Update(string json, int userId);
    }
}
