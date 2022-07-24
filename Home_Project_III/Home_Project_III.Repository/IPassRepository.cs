using Home_Project_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Repository
{
    public interface IPassRepository
    {
        public IQueryable<PasswordSecurity> ReadAll();
        public void Create(string json);
        public PasswordSecurity Read(int userID);
        public void Delete(int passId);
        public void Update(string json, int passId);
    }
}
