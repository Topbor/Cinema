using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public string Cast { get; set; }
        public string Studio { get; set; }
        public string Director { get; set; }
        public string Language { get; set; }
        public int ChoronoHours { get; set; }
        public int ChoronoMinutes { get; set; }
        public string Img { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public Film()
        {
            Sessions = new List<Session>();
        }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int ShowStaus { get; set; }
    }
}