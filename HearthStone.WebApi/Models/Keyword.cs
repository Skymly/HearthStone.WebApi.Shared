namespace HearthStone.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public string RefText { get; set; }
        public string Text { get; set; }
        public int[] GameModes { get; set; }
    }
}
