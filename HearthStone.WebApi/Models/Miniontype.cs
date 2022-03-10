namespace HearthStone.Models
{
    public class Miniontype 
    {
        public string Slug { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> GameModes { get; set; }
    }
}
