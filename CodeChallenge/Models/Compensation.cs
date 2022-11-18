using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        [Key]
        public string Id { get; set; }
        public Employee Employee { get; set; }
        public string Salary { get; set; }
        public DateTime EffectiveDate { get; set; }
    }
}