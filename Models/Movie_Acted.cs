namespace IndianMovies.Models
{
    

    public class Movie_Acted
    {
        public int Movie_ActedID { get; set; }
        public int MovieID { get; set; }
        public int ActorID { get; set; }
        

        public virtual Movie Movie { get; set; }
        public virtual Actor Actor { get; set; }
    }
}