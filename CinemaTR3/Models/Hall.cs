using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaTR3.Models
{
    public class Hall
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Desc { get; set; }
        public int Number { get; set; }
        public ICollection<Place> Places { get; set; }
        public ICollection<Session> Sessions { get; set; }
        public Hall()
        {
            Places = new List<Place>();
            Sessions = new List<Session>();
        }
    }
}