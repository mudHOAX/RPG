using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public readonly ItemCollection<Weapon> weapons = new ItemCollection<Weapon> { };
    public readonly ItemCollection<Armour> armours = new ItemCollection<Armour> { };
    public readonly ItemCollection<Consumable> consumables = new ItemCollection<Consumable> { };

    private Dictionary<Type, string> resourceMap = new Dictionary<Type, string>
    {
        { typeof(Weapon), "Items/weapons" },
        { typeof(Armour), "Items/armours" },
        { typeof(Consumable), "Items/consumables" }
    };

    public ItemManager()
    {
        weapons = Load<Weapon>();
        armours = Load<Armour>();
        consumables = Load<Consumable>();
    }

    private ItemCollection<T> Load<T>() where T : Item
    {
        string resourcePath;

        if (resourceMap.TryGetValue(typeof(T), out resourcePath)) {
            TextAsset resource = Resources.Load(resourcePath) as TextAsset;
            ItemCollection<T> deserializedItems = JsonConvert.DeserializeObject<ItemCollection<T>>(resource.ToString());
            return deserializedItems;
        }

        return null;
    }
}