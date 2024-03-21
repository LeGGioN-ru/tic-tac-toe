public class Currency : Item
{
    public int Amount { get;private set; }
    
    public Currency(string key,int amount) : base(key)
    {
        Amount = amount;
    }
}
