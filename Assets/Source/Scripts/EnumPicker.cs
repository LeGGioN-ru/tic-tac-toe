using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public abstract class EnumPicker<T, T2> : IInitializable where T : Enum where T2 : MonoBehaviour
{
    private readonly Dictionary<T, List<T2>> _items = new Dictionary<T, List<T2>>();
    private readonly Dictionary<T, T2> _notInitItems = new Dictionary<T, T2>();
    private readonly Transform _transform;
    private readonly int _amountItemsInPool;
    private readonly DiContainer _container;
    private readonly bool _isPool;

    public EnumPicker(Dictionary<T, T2> items, Transform itemsTransform, DiContainer diContainer, int amountItemsInPool = 1)
    {
        _amountItemsInPool = amountItemsInPool;
        _container = diContainer;
        _isPool = true;
        _notInitItems = items;
        _transform = itemsTransform;
    }

    public virtual void Initialize()
    {
        if (_isPool)
        {
            foreach (var item in _notInitItems)
            {
                List<T2> itemList = new List<T2>();

                for (int i = 0; i < _amountItemsInPool; i++)
                {
                    T2 obj = CreateObject(item.Value, _transform);
                    obj.gameObject.SetActive(false);

                    itemList.Add(obj);
                }

                _items.Add(item.Key, itemList);
            }
        }
    }

    public EnumPicker(Dictionary<T, T2> items)
    {
        _isPool = false;

        foreach (var item in items)
        {
            List<T2> itemList = new List<T2>() { item.Value };

            _items.Add(item.Key, itemList);
        }
    }

    public virtual T2 GetItem(T @enum)
    {
        if (_items.ContainsKey(@enum))
        {
            T2 obj = null;

            if (_isPool)
                obj = _items[@enum].FirstOrDefault(x => x.gameObject.activeSelf == false);
            else
                obj = _items[@enum].FirstOrDefault();

            if (obj != null)
                return obj;

            throw new Exception($"Can't find free element in pool");
        }


        Debug.Log(_items.Count);
        throw new ArgumentException($"Items must contains {@enum} key.");
    }

    public virtual T3 GetItem<T3>(T @enum) where T3 : MonoBehaviour
    {
        T2 currentTypeObject = GetItem(@enum);
        T3 needType = currentTypeObject as T3;

        if (needType != null)
            return needType;

        throw new Exception($"Object with base type {currentTypeObject.GetType().Name} and with key {typeof(T).Name} can't cast to {typeof(T3).Name}");
    }

    protected virtual T2 CreateObject(T2 prefab, Transform transform)
    {
        return _container.InstantiatePrefabForComponent<T2>(prefab, transform);
    }
}
