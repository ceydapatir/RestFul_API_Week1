using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohorts_Week1
{
    public class Film
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double IMDB { get; set; }
        public int GenreId { get; set; }
        public string? Director { get; set; }
        public DateTime PublishDate { get; set; }
    }
}