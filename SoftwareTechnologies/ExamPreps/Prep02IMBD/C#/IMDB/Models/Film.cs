﻿namespace IMDB.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Genre { get; set; }


        [Required]
        public string Director{ get; set; }

        [Required]
        public int Year { get; set; }
        
    }
}
