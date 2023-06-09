﻿using PokemonAPI.Dto;

namespace PokemonAPI.Models
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Review> Reviews { get; set;}
        public ReviewerDto ToDto()
        {
            return new ReviewerDto
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
