using System.Collections.Generic;

public class Product : IKeyable
{
    private Item[] _items;

    public string Key { get; private set; }
    public float Price { get; private set; }
    public IReadOnlyCollection<Item> Items => _items;

    public Product(Item[] items)
    {
        _items = items;
    }
}
