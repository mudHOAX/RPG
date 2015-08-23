using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ItemMenu : Menu
{
    public void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 100), "Items");
    }
}