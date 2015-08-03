using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public static class ItemManager
{
    public static readonly ItemCollection<Weapon> Weapons = Load<Weapon>();
    public static readonly ItemCollection<Armour> Armours = Load<Armour>();
    public static readonly ItemCollection<Consumable> Consumables = Load<Consumable>();
    
    private static ItemCollection<T> Load<T>() where T : Item
    {
        Dictionary<Type, string> resourceMap = new Dictionary<Type, string>
        {
            { typeof(Weapon), "Items/weapons" },
            { typeof(Armour), "Items/armours" },
            { typeof(Consumable), "Items/consumables" }
        };

        string resourcePath;

        if (resourceMap.TryGetValue(typeof(T), out resourcePath)) {
            TextAsset resource = Resources.Load(resourcePath) as TextAsset;
            ItemCollection<T> deserializedItems = JsonConvert.DeserializeObject<ItemCollection<T>>(resource.ToString());
            return deserializedItems;
        }

        return null;
    }
}