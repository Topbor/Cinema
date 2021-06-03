using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Place
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public int? HallId { get; set; }
        public Hall Hall { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Place()
        {
            Tickets = new List<Ticket>();
        }
    }
}