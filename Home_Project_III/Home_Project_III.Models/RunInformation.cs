﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Project_III.Models
{
    [Table("Runs")]
    public class RunInformation 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RunID { get; set; }
        [ForeignKey(nameof(UserInformation))]
        public int UserID { get; set; }
        //[NotMapped]
        public virtual UserInformation userInfo { get; set; }
        public double Distance { get; set; }
        public string Time { get; set; }
        public bool IsCompetition { get; set; }
        public string Location { get; set; }
        public override string ToString()
        {
            return $"Id : {UserID}, RunID: {RunID}, Time: {Time.Trim()}, Distance: {Distance}, Location: {Location.Trim()}";
        }
    }
}
