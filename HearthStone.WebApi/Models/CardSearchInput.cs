namespace HearthStone.Models
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class CardSearchInput
    {

        [AliasAs("set")]
        public string Set { get; set; } = null;

        [AliasAs("class")]
        public string Class { get; set; } = null;

        [AliasAs("manaCost")]
        public int? ManaCost { get; set; } = null;

        [AliasAs("attack")]
        public int? Attack { get; set; } = null;

        [AliasAs("health")]
        public int? Health { get; set; } = null;

        [AliasAs("collectible")]
        public int? Collectible { get; set; } = null;

        [AliasAs("rarity")]
        public string Rarity { get; set; } = null;

        [AliasAs("type")]
        public string Type { get; set; } = null;

        [AliasAs("minionType")]
        public string MinionType { get; set; } = null;

        [AliasAs("keyword")]
        public string Keyword { get; set; } = null;

        [AliasAs("textFilter")]
        public string TextFilter { get; set; } = null;

        [AliasAs("gameMode")]
        public string GameMode { get; set; } = null;

        [AliasAs("spellSchool")]
        public string SpellSchool { get; set; } = null;

        [AliasAs("page")]
        public int? Page { get; set; } = null;

        [AliasAs("pageSize")]
        public int? PageSize { get; set; } = null;

        [AliasAs("sort")]
        public string Sort { get; set; } = null;
    }
}