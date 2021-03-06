﻿using System.Collections.Generic;

namespace GameStore.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActiveOffer { get; set; } = false;
        public string ImageUrl { get; set; }
        public List<GameGenre> GameGenres { get; set; }
    }
}
