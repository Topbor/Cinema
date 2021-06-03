using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int? SessionId { get; set; }
        public Session Session { get; set; }
        public int? PlaceId { get; set; }
        public Place Place { get; set; }
        public int Price { get; set; }
        public int Status { get; set; }
        public ICollection<Pivot> Pivots { get; set; }
        public Ticket()
        {
            Pivots = new List<Pivot>();
        }
    }
}