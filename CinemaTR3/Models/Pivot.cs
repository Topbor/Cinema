using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Pivot
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}