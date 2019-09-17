using System.ComponentModel.DataAnnotations;
using System;

    namespace CRUDelicious.Models
    {
        public class Dish
        {
            // auto-implemented properties need to match the columns in your table
            // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
            [Key]
            public int DishId { get; set; }
            // MySQL VARCHAR and TEXT types can be represeted by a string

            [Required(ErrorMessage="Name of Dish is required!")]
            public string Name { get; set; }

            [Required(ErrorMessage="Chef's Name is required!")]
            public string Chef { get; set; }

            [Required(ErrorMessage="Tastiness Score is required!")]
            [Range(1,5, ErrorMessage="Tastiness must be between 1 and 5")]

            public int Tastiness { get; set; }

            [Required(ErrorMessage="Calories is required!")]
            public int Calories { get; set; }

            [Required(ErrorMessage="Description is required!")]
            public string Description { get; set; }
            // The MySQL DATETIME type can be represented by a DateTime
            public DateTime CreatedAt {get;set;}
            public DateTime UpdatedAt {get;set;}
        }
    }