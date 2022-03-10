namespace HearthStone.Models
{
    public class CardClass
    {
        public string Slug { get; set; }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CardId { get; set; }
        public int HeroPowerCardId { get; set; }
        public List<int> AlternateHeroCardIds { get; set; }
    }
}
