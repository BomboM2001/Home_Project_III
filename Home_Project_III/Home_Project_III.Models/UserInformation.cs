using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Models
{
    [Table("Users")]
    public class UserInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserID { get; set; }
        public string Full_Name { get; set; }
        public int Age { get; set; }
        public double Weight { get; set; }
        public int Height { get; set; }
        public string Email { get; set; }
        public bool Premium { get; set; }
        public virtual ICollection<RunInformation> runInfo { get; set; }

        public override string ToString()
        {
            return $"Id: {UserID}, Name: {Full_Name.Trim()}, Age: {Age}, Weight: {Weight}, Height: {Height}, Email: {Email.Trim()}";
        }
    }
}
