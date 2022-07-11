﻿namespace ProductsAPI.Models.DTos
{
    public record ProductTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanBeInsured { get; set; }
    }
}
