using AYellowpaper.SerializedCollections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShopInstaller : MonoInstaller
{
    [SerializeField] private Transform _container;
    [SerializeField] private SerializedDictionary<string, AdditionalInfo> _additionalInfos;
    [SerializedDictionary("Key", "AdditionalInfo")]

    public override void InstallBindings()
    {

    }
}
