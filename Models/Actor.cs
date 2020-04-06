using System;
using System.Collections.Generic;

namespace IndianMovies.Models
{
    public class Actor
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime MovieReleaseDate { get; set; }

        public virtual ICollection<Movie_Acted> Movie_Acted { get; set; }
    }
}