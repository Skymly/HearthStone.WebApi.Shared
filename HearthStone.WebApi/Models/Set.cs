namespace HearthStone.Models
{
    public class Set
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Type { get; set; }
        public int CollectibleCount { get; set; }
        public int CollectibleRevealedCount { get; set; }
        public int NonCollectibleCount { get; set; }
        public int NonCollectibleRevealedCount { get; set; }
        public int[] AliasSetIds { get; set; }
    }
}
