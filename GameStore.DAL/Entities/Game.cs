namespace GameStore.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsActiveOffer { get; set; }
        public string ImageUrl { get; set; }
    }
}
