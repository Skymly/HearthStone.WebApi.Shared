namespace HearthStone.Models
{
    public class Rarity
    {
        public string Slug { get; set; }
        public int Id { get; set; }
        public List<int?> CraftingCost { get; set; }
        public List<int?> DustValue { get; set; }
        public string Name { get; set; }
    }
}