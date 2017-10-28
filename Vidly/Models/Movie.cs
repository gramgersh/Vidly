using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        public int NumberInStock { get; set; }

        // The Genre is required.  The EF takes care of setting GenreID to not-nullable.
        [Required]
        public Genre Genre { get; set; }
        public byte GenreID { get; set; }
    }
}