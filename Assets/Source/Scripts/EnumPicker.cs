using System;
using System.Collections.Generic;

public abstract class EnumPicker<T, T2> where T : struct where T2 : class
{
    private readonly Dictionary<T, T2> _items = new Dictionary<T, T2>();

    public EnumPicker(Dictionary<T, T2> items)
    {
        if (!typeof(T).IsEnum)
        {
            throw new ArgumentException("T must be an enumerated type");
        }

        _items = items;
    }

    protected T2 GetItem(T @enum)
    {
        if (_items.ContainsKey(@enum))
        {
            return _items[@enum];
        }

        throw new ArgumentException($"Items must contains {@enum} key.");
    }
}
