using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Session
    {
        public int Id { get; set; }
        public int? FilmId { get; set; }
        public Film Film { get; set; }
        public int? HallId { get; set; }
        public Hall Hall { get; set; }
        public DateTime DateTime { get;  set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Session()
        {
            Tickets = new List<Ticket>();
        }
        public int ShowStatus { get; set; }
    }
}
