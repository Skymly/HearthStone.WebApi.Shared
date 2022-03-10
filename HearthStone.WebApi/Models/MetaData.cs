namespace HearthStone.Models
{
    public class MetaData
    {
        public List<Set> Sets { get; set; }
        public List<SetGroup> SetGroups { get; set; }
        public List<GameMode> GameModes { get; set; }
        public List<int> ArenaIds { get; set; }
        public List<CardType> Types { get; set; }
        public List<Rarity> Rarities { get; set; }
        public List<CardClass> Classes { get; set; }
        public List<Miniontype> MinionTypes { get; set; }
        public List<SpellSchool> SpellSchools { get; set; }
        public List<MercenaryRole> MercenaryRoles { get; set; }
        public List<Keyword> Keywords { get; set; }
        public List<string> FilterableFields { get; set; }
        public List<string> NumericFields { get; set; }
        public List<CardBackCategory> CardBackCategories { get; set; }
    }
}
