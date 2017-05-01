using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SonOfCod.Models
{
    [Table("Visitors")]
    public class Visitor
    {
        [Key]
        public int VisitorId { get; set; }
        public string VisitorEmail { get; set; }
        public string MonthlySpending { get; set; }
        public int AmountPeople { get; set; }
        public string Reason { get; set; }
    }
}
