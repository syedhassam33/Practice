﻿using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;

namespace PokemonAPI.Data
{
    public class PokemonDbContext : DbContext
    {
        public PokemonDbContext(DbContextOptions<PokemonDbContext> options) : base(options)
        {

        }

        public DbSet<Pokemon_Table> Pokemons { get; set; }
    }
}
