using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQModel
{
    public class Holding
    {
      [Key]
      public int Id { get; set; }
      public int Share { get; set; }
      [ForeignKey("Stock")]
      public int StockId { get; set; }
      [ForeignKey("Customer")]
      public int CustomerId { get; set; }
      
      public Stock Stock { get; set; }
      public Customer Customer { get; set; }
    }
}
