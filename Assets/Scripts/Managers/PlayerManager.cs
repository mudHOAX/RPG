using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager instance;

    private const byte MAX_INVENTORY = 99;
    
    private BaseCharacter[] party = new BaseCharacter[] { new Vivi() };
    private Dictionary<Item, byte> inventory = new Dictionary<Item, byte>(); 
    private uint availableGil = 0;
    private Stopwatch gameTime = new Stopwatch();
    
    private bool inGameMenuOpen = false;
    
    public static PlayerManager Instance { get { return (instance == null) ? instance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>() : instance; } }
    public PlayerManager()
    {
        gameTime.Start();

        BaseCharacter vivi = new Vivi();
        vivi.AddExperience(1053);
        vivi.BattleRow = BattleRow.Back;

        BaseCharacter zidane = new Zidane();
        zidane.AddExperience(1469);

        BaseCharacter garnet = new Garnet();
        garnet.AddExperience(589);
        garnet.BattleRow = BattleRow.Back;

        BaseCharacter stenier = new Stenier();
        stenier.AddExperience(1230);
        
        party = new BaseCharacter[] { zidane, vivi, garnet, stenier };

        instance = this;
    }

    public TimeSpan GameTime { get { return TimeSpan.FromTicks(gameTime.ElapsedTicks); } }

    public BaseCharacter[] Party { get { return party; } }

    public Dictionary<Item, byte> Inventory { get { return inventory; } }

    public void AddItemToInventory(Item item)
    {
        if (inventory.ContainsKey(item))
            if (inventory[item] < MAX_INVENTORY)
                inventory[item]++;
            else
                throw new Exception(string.Format("Cannot add another item: {0} slot is full", item));
        else
            inventory.Add(item, 1);
    }

    public void RemoveItemFromInventory(Item item)
    {
        if (!inventory.ContainsKey(item))
            throw new Exception(string.Format("Item {0} does not exist in inventory", item));

        if (inventory[item] >= 1)
            inventory.Remove(item);
        else
            inventory[item]--;
    }

    public uint AvailableGil { get { return availableGil; } }

    public void IncreaseGil(uint amount)
    {
        availableGil += amount;
    }

    public bool TryReduceGil(uint amount, out uint actualAmount)
    {
        if ((availableGil - amount) < 0)
        {
            actualAmount = availableGil;
            ReduceGil(actualAmount);
            return false;
        }

        ReduceGil(amount);
        actualAmount = amount;
        return true;
    }

    private void ReduceGil(uint amount)
    {
        availableGil -= amount;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inGameMenuOpen)
        {
            inGameMenuOpen = true;
            new GameObject("InGameMenu").AddComponent<InGameMenu>();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inGameMenuOpen)
        {
            inGameMenuOpen = false;
            DestroyImmediate(GameObject.Find("InGameMenu"));
        }
    }
}