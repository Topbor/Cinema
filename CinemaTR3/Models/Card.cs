using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Card
    {
        public int TicketId { get; set; }
        public int Place { get; set; }
        public string Session { get; set; }
        public int price { get; set; }
    }
}