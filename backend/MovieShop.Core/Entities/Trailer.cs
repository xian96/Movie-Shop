using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    //One movie can have multiple trailers
    public class Trailer
    {
        public int Id { get; set; }
        //foreign key from movie table which is id as pk there
        public int MovieId { get; set; }
        public string  TrailerUrl { get; set; }
        public string  Name { get; set; }

        //navigation properties, help is navigate to related entities
        //trailerid 24 => get me movie tilte and overview..
        public Movie Movie { get; set; }
    }
}
