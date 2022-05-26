using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author_first_name { get; set; }
        public string Author_last_name { get; set; }
        public decimal Price { get; set; }
        public string Short_desc { get; set; }
        public int Amount { get; set; }
    }
}
