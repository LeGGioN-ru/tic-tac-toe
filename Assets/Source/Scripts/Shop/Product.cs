using System.Collections.Generic;

public class Product : IKeyable, IAdditionalInfoSettable
{
    private readonly Item[] _items;

    public string Key { get; private set; }
    public float Price { get; private set; }
    public IReadOnlyCollection<Item> Items => _items;
    public AdditionalInfo AdditionalInfo { get; private set; }


    public Product(Item[] items)
    {
        _items = items;
    }

    public void SetAdditionalInfo(AdditionalInfo additionalInfo)
    {
        AdditionalInfo = additionalInfo;
    }
}
