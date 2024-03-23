public abstract class Item : IKeyable, IAdditionalInfoSettable
{
    public string Key { get; private set; }
    public AdditionalInfo AdditionalInfo { get; private set; }

    public Item(string key)
    {
        Key = key;
    }

    public void SetAdditionalInfo(AdditionalInfo additionalInfo)
    {
        AdditionalInfo = additionalInfo;
    }
}
