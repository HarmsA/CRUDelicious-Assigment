using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishID {get;set;}
        [Required]
        public string ChefName {get;set;}
        [Required]
        public string DishName {get;set;}
        [Required]
        [Range(0,4000, ErrorMessage = "Either its celery your your trying to give me a heart attach when I eat this. Only 0-4000 calories accepted.")]
        public int Calories {get;set;}
        [Required]
        [Range(1,5)]
        public int Tastiness {get;set;}
        [Required(ErrorMessage = "Yes this is also required")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}