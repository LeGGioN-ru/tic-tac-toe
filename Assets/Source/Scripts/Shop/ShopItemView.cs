using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image _mainImage;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _price;

    private Item _item;
    protected Product Product;

    [Inject]
    public virtual void Construct(Product product, List<Item> items)
    {
        if (items.Count > 1)
            throw new ArgumentException();

        _item = items.FirstOrDefault();
        Product = product;
    }

    protected virtual void Start()
    {
        Init(_item, Product);
    }

    protected virtual void Init(Item item, Product product)
    {
        _mainImage.sprite = item.AdditionalInfo.Sprite;
        _name.text = item.AdditionalInfo.Name;
        _description.text = item.AdditionalInfo.Description;
        _price.text = product.Price.ToString() + "$";
    }
}
