﻿using PokemonAPI.Dto;

namespace PokemonAPI.Models
{
    public class Owner
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gym { get; set; }
        public Country Country { get; set; }
        public ICollection<PokemonOwner> PokemonOwners { get; set; }
        public OwnerDto ToDto()
        {
            return new OwnerDto
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Gym = Gym
            };
        }
    }
}
