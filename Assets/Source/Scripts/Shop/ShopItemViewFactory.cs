using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class ShopItemViewFactory : IFactory<Transform, List<Product>, ShopItemView>
{
    private readonly DiContainer _container;
    private readonly ShopItemView _oneItemView;
    private readonly ShopItemView _moreItemView;

    public ShopItemViewFactory(DiContainer container, ShopItemView oneItemView, ShopItemView moreItemsView)
    {
        _container = container;
        _oneItemView = oneItemView;
        _moreItemView = moreItemsView;
    }

    public ShopItemView Create(Transform container, Product product)
    {
        if (product.Items.Count == 1)
        {
            return _container.InstantiatePrefabForComponent<ShopItemView>(_oneItemView, container, new object[] { product, product.Items.FirstOrDefault() });
        }
        else
        {
            return _container.InstantiatePrefabForComponent<ShopItemView>(_moreItemView, container, new object[] { products });
        }
    }
}
