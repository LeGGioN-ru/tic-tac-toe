public abstract class Item : IKeyable
{
    public string Key { get; private set; }

    public Item(string key)
    {
        Key = key;
    }
}
