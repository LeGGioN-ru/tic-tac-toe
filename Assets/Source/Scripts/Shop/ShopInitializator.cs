using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopInitializator : IInitializable
{
    private readonly string _jsonString;
    private readonly Transform _container;
    private readonly ShopItemView _shopItemView;
    private readonly Dictionary<string, AdditionalInfo> _additionalInfos;

    public ShopInitializator(string jsonString, ShopItemView shopItemView, Dictionary<string, AdditionalInfo> additionalInfos,
        Transform container)
    {
        _container = container;
        _jsonString = jsonString;
        _shopItemView = shopItemView;
        _additionalInfos = additionalInfos;
    }

    public void Initialize()
    {
        JsonSerializerSettings settings = new JsonSerializerSettings();
        settings.Converters.Add(new ShopItemsParser());
        List<Product> products = JsonConvert.DeserializeObject<List<Product>>(_jsonString, settings);
        SetAdditionalsInfos(products);

    }

    private void SetAdditionalsInfos(List<Product> products)
    {
        foreach (var product in products)
        {
            SetInfo(product);

            foreach (var item in product.Items)
            {
                SetInfo(item);
            }
        }
    }

    private void SetInfo(IAdditionalInfoSettable additionalInfoSettable)
    {
        if (_additionalInfos.ContainsKey(additionalInfoSettable.Key))
            additionalInfoSettable.SetAdditionalInfo(_additionalInfos[additionalInfoSettable.Key]);
    }
}
