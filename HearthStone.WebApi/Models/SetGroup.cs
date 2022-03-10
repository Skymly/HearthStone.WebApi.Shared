namespace HearthStone.Models
{
    public class SetGroup 
    {
        public string Slug { get; set; }
        public int Year { get; set; }
        public string Svg { get; set; }
        public List<string> CardSets { get; set; }
        public string Name { get; set; }
        public bool Standard { get; set; }
        public string Icon { get; set; }
        public string YearRange { get; set; }
    }
}
