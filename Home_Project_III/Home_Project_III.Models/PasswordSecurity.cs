using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Models
{
    [Table("Passwords")]
    public class PasswordSecurity : IModelClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PassId { get; set; }
        [ForeignKey(nameof(UserInformation))]
        public int UserId { get; set; }
        public string RecoverPhoneNumber { get; set; }
        public virtual UserInformation UserInformation { get; set; }
        public string TotallySecuredVeryHashedPassword { get; set; }

        public override string ToString()
        {
            return $"PassID: {PassId}, UserID: {UserId}, Phone number: {RecoverPhoneNumber.Trim()}, Password: {TotallySecuredVeryHashedPassword.Trim()}";
        }
    }
}
