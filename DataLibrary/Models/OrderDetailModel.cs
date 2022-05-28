using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class OrderDetailModel
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
    }
}
