public class Weapon : Item
{
    public int Damage { get; private set; }

    public Weapon(string key, int damage) : base(key)
    {
        Damage = damage;
    }
}
