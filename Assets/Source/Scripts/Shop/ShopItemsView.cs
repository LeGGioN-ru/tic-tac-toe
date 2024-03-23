using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopItemsView : ShopItemView
{
    [SerializeField] private Transform _container;

    private List<Item> _items;

    [Inject]
    public override void Construct(Product product, List<Item> items)
    {
        base.Construct(product, items);

        _items = items;
    }

    protected override void Start()
    {
        base.Start();
    }
}
