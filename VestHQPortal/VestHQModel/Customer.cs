using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQModel
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50), Required]
        public string FirstName { get; set; }
        [StringLength(50),Required]
        public string LastName { get; set; }
        [StringLength(200)]
        public string TwitterAccount { get; set; }
        [ForeignKey("Employer")]
        public int EmployerId { get; set; }
                
        public Employer Employer { get; set; }
    }
}
