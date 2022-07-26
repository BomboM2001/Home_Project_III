using Home_Project_III.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Logic
{
    public interface IPassLogic
    {
        public void Create(string json);

        public IQueryable<PasswordSecurity> ReadAll();
        public void Delete(int passId);
        public void Update(string json, int userId);
        public PasswordSecurity Read(int userId);

        public IEnumerable<int> GetOldPeoplesPassID();
        public IEnumerable<int> GetOldPeoplesPassIDWithWeakPassword();
        public IEnumerable<int> GetPassIDOfPremiumUsers();
        public IEnumerable<string> GetPhoneNumberOfPremiumUsers();
        public IEnumerable<string> GetPhoneNumberOfCompetitors();
    }
}
