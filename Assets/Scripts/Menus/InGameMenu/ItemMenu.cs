using System;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenu : Menu
{
    private List<GUIControl> controls;
    private GUINavigableControlGroup itemsMenu;

    public override void OnGUI()
    {
        base.OnGUI();

        if (controls == null)
            controls = new List<GUIControl>
            {
                new GUIControl { Name = "menu-items-use", Label = "Use", Action = () => { /*MenuManager.LoadMenu<ItemMenu>();*/ } },
                new GUIControl { Name = "menu-items-arrange", Label = "Arrange", Action = () => { /*MenuManager.LoadMenu<ItemMenu>();*/ }},
                new GUIControl { Name = "menu-items-key", Label = "Key", Action = () => { /*MenuManager.LoadMenu<ItemMenu>();*/ }}
            };

        // Main Menu
        float mainMenuLeft = (float)(Screen.width / 2 - Math.Floor(menuResolution.x / 2)) + 25;
        float mainMenuHeight = 50.0f;
        float mainMenuTop = (Screen.height / 2 - (mainMenuHeight * 6));
        float mainMenuWidth = menuResolution.x - 200.0f;

        if (PrimaryNavigation == null)
            PrimaryNavigation = new GUINavigableControlGroup(controls.ToArray(), new Rect(mainMenuLeft, mainMenuTop, mainMenuWidth, mainMenuHeight), new Vector2(10, 10), GUIItemsGroup.Orientation.Horizontal);
        PrimaryNavigation.Render();

        float menuLabelBoxLeft = mainMenuLeft + mainMenuWidth + 10;
        float menuLabelBoxHeight = 50.0f;
        float menuLabelBoxWidth = 190.0f;

        GUINavigableControlGroup itemsMenuLabel = new GUINavigableControlGroup(new GUIControl[] { new GUIControl { Name = "menu-items", Label = "Items" } }, new Rect(menuLabelBoxLeft, mainMenuTop, menuLabelBoxWidth, menuLabelBoxHeight), new Vector2(10, 10), GUIItemsGroup.Orientation.Vertical);
        itemsMenuLabel.Render();

        // Items
        float menuBoxLeft = (float)(Screen.width / 2 - Math.Floor(menuResolution.x / 2)) + 25;
        float itemsBoxHeight = 150.0f;
        float itemsBoxWidth = menuResolution.x;

        if (itemsMenu == null)
            itemsMenu = new GUINavigableControlGroup(new GUIControl[] { }, new Rect(menuBoxLeft, Screen.height / 2 - ((itemsBoxHeight * 4) / 2) + 60, itemsBoxWidth, itemsBoxHeight * 4 - 60), GUIItemsGroup.Orientation.Vertical);
        itemsMenu.Render();
    }
}