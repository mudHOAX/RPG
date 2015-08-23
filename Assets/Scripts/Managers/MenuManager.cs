using System;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private bool inGame = true;
    private static Stack<Type> menuHistory = new Stack<Type>();
    private static Menu currentMenu;

    public bool InGameMenuOpen { get { return menuHistory.Count > 0; } }

    public void Update()
    {
        if (inGame)
        {
            if (!InGameMenuOpen && Input.GetButtonDown("PS4_Triangle"))
                LoadMenu<InGameMenu>();
            else if (InGameMenuOpen && currentMenu.CanNavigateAway() && Input.GetButtonDown("PS4_Circle"))
                LoadPreviousMenu();
            else if (InGameMenuOpen && Input.GetButtonDown("PS4_Triangle"))
                while (InGameMenuOpen)
                    CloseCurrentMenu();
        }
    }

    public static void LoadMenu<T>() where T : Menu
    {
        if (menuHistory.Count > 0)
            DestroyImmediate(GameObject.Find(menuHistory.Peek().FullName));

        menuHistory.Push(typeof(T));
        currentMenu = new GameObject(typeof(T).FullName).AddComponent<T>();
    }

    public static void LoadMenu<T>(BaseCharacter character) where T : CharacterMenu
    {
        LoadMenu<T>();
        ((CharacterMenu)currentMenu).CharacterInfo = character;
    }

    private void CloseCurrentMenu()
    {
        if (menuHistory.Count <= 0)
            return;

        Type menu = menuHistory.Pop();
        DestroyImmediate(GameObject.Find(menu.FullName));
    }

    private void LoadPreviousMenu()
    {
        CloseCurrentMenu();

        if (menuHistory.Count <= 0)
            return;
        
        Type newMenu = menuHistory.Peek();
        GameObject gameObject = new GameObject(newMenu.FullName);
        gameObject.GetType().GetMethod("AddComponent", Type.EmptyTypes).MakeGenericMethod(newMenu).Invoke(gameObject, null);
        currentMenu = (Menu)gameObject.GetComponent(newMenu.FullName);
    }
}