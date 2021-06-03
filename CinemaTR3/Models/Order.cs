using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Pivot> Pivots { get; set; }
        public Order()
        {
            Pivots = new List<Pivot>();
        }
    }
}