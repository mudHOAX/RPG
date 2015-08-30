using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    protected GUINavigableItemsGroup primaryNavigation;
    protected Stack<GUINavigableItemsGroup> navigationHistory = new Stack<GUINavigableItemsGroup>();
    protected Vector2 menuResolution = new Vector2(1024, 768);
    protected Texture2D menuBackgroundTexture;
    protected Texture2D menuBoxTexture;

    protected GUINavigableItemsGroup PrimaryNavigation
    {
        get { return primaryNavigation; }
        set
        {
            primaryNavigation = value;
            primaryNavigation.isPrimary = true;
            ChangeNavigation(value);
        }
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("PS4_Circle"))
        {
            SoundManager.PlaySoundEffect(SoundEffects.CursorCancel);
            NavigateBack();
        }
        else if (Input.GetButtonDown("PS4_Cross") && navigationHistory.Count > 0)
        {
            SoundManager.PlaySoundEffect(SoundEffects.Cursor);
            navigationHistory.Peek().CurrentItem.Invoke();
        }
    }

    public void ChangeNavigation(GUINavigableItemsGroup navigation)
    {
        if (navigationHistory.Count > 0) 
            navigationHistory.Peek().Deactivate();

        navigation.Activate();
        navigationHistory.Push(navigation);
    }

    public virtual void OnGUI()
    {

        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), menuBackgroundTexture);
    }

    public virtual bool CanNavigateAway()
    {
        return navigationHistory.Count <= 1;
    }

    private void NavigateBack()
    {
        if (navigationHistory.Count > 1)
        {
            navigationHistory.Pop().Deactivate();
            navigationHistory.Peek().Activate();
        }
    }
}