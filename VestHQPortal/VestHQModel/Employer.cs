using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace VestHQModel
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string EmployerName { get; set; }

        public ICollection <Customer> Customers { get; set; }
    }
}
