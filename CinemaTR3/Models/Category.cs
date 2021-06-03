using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Img { get; set; }
        public ICollection<Film> Films { get; set; }
        public Category()
        {
            Films = new List<Film>();
        }
    }
}