public interface IAdditionalInfoSettable
{
    public string Key { get; }
    public AdditionalInfo AdditionalInfo { get; }

    public void SetAdditionalInfo(AdditionalInfo additionalInfo);
}
