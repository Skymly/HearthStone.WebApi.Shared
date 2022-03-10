namespace HearthStone.Models;
[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
public class CardBackSearchInput
{
    public CardBackSearchInput()
    {
    }

    [AliasAs("cardBackCategory")]
    public string CardBackCategory { get; set; } = null;

    [AliasAs("textFilter")]
    public string TextFilter { get; set; } = null;

    [AliasAs("page")]
    public int? Page { get; set; } = null;

    [AliasAs("pageSize")]
    public int? PageSize { get; set; } = null;

    [AliasAs("sort")]
    public string Sort { get; set; } = null;
}
public class CardBackSearchResult
{
    public CardBack[] CardBacks { get; set; }
    public int CardCount { get; set; }
    public int PageCount { get; set; }
    public int Page { get; set; }
}

public class CardBack
{
    

    public int Id { get; set; }
    public int SortCategory { get; set; }
    public string Text { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
    public string Slug { get; set; }
}

