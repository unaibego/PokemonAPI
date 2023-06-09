﻿using PokemonAPI.Models;

namespace PokemonAPI.Dto
{
    public class PokemonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Pokemon NotDto()
        {
            return new Pokemon
            {
                Id = Id,
                Name = Name,
                BirthDate = BirthDate,
            };
        }
    }
}
