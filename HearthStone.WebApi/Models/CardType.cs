namespace HearthStone.Models
{
    public class CardType 
    {
        public string Slug { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int[] GameModes { get; set; }
    }
}
