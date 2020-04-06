using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndianMovies.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public double Rating { get; set; }

        public virtual ICollection<Movie_Acted> Movie_Acted { get; set; }
    }
}