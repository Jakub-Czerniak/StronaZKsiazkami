using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StronaZKsiazkami.Models
{
    public class GenreModel
    {
        public int Id { get; set; }
        public string GenreName { get; set; }
        public bool IsSelected { get; set; }
    }
}