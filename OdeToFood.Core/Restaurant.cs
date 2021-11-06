using System;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Core
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

        public CuisineType Cuisine { get; set; }


    }

    public class Detail
    {
        [Required]
        public DateTime Founded { get; set; }

        [Required]
        public string SignatureFlavour { get; set; }
        [Required]
        public string AboutUs { get; set; }
    }

}
