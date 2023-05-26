﻿using PokemonAPI.Dto;
using PokemonAPI.Models;

namespace PokemonAPI.Interface
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        PokemonDto GetPokemon(int id);
        PokemonDto GetPokemon(string name);
        decimal GetPokemonRating(int pokeId);
        bool PokemonExists(int pokeId);
    }
}