﻿using System.ComponentModel.DataAnnotations;

namespace CaartingService.API.Entities
{
    public class Item
    {
        [Required]
        public string CartId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Amount { get; set; }

        public string ImageURL { get; set; }

    }
}
