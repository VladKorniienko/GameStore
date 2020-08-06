using System.Collections.Generic;

namespace GameStore.DAL.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SubgenreId { get; set; }
        public List<GameGenre> GameGenres { get; set; }
    }
}
