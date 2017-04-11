using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQModel
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        [StringLength(4, MinimumLength = 1),Required]
        public string Symbol { get; set; }
             
        public ICollection<StockPriceHistory> StockHistories { get; set; }
    }
}
