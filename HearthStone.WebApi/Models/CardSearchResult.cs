namespace HearthStone.Models
{
    public class CardSearchResult
    {
        public Card[] Cards { get; set; }
        public int CardCount { get; set; }
        public int PageCount { get; set; }
        public int Page { get; set; }
    }
}
