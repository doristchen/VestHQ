using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VestHQModel
{
    public class StockPriceHistory
    {
        [Key]
        public int Id { get; set; }
        [Column(Order = 1), ForeignKey("Stock")]
        public int StockId { get; set; }
        [Column("DateTime", TypeName = "smalldatetime")]
        public DateTime Date { get; set; }
        public double Price { get; set; }
   
        public Stock Stock { get; set; }
    }
}
