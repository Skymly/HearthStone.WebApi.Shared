namespace HearthStone.Models;
public class Card
{
    public int Id { get; set; }
    public int Collectible { get; set; }
    public string Slug { get; set; }
    public int ClassId { get; set; }
    public List<int> MultiClassIds { get; set; }
    public int MinionTypeId { get; set; }
    public int CardTypeId { get; set; }
    public int CardSetId { get; set; }
    public int RarityId { get; set; }
    public string ArtistName { get; set; }
    public int Health { get; set; }
    public int Attack { get; set; }
    public int ManaCost { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string Image { get; set; }
    public string ImageGold { get; set; }
    public string FlavorText { get; set; }
    public string CropImage { get; set; }
    public List<int> KeywordIds { get; set; }
    public Duels Duels { get; set; }
    public List<int> ChildIds { get; set; }
    public int ParentId { get; set; }
    public int Armor { get; set; }
    public int SpellSchoolId { get; set; }
    public int CopyOfCardId { get; set; }
    public int Durability { get; set; }
}
