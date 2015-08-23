using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    protected GUINavigableControlGroup primaryNavigation;
    protected Stack<GUINavigableControlGroup> navigationHistory = new Stack<GUINavigableControlGroup>();

    protected GUINavigableControlGroup PrimaryNavigation
    {
        get { return primaryNavigation; }
        set
        {
            primaryNavigation = value;
            ChangeNavigation(value);
        }
    }

    public virtual void Update()
    {
        if (Input.GetButtonDown("PS4_Circle"))
            NavigateBack();
        else if (Input.GetButtonDown("PS4_Cross") && navigationHistory.Count > 0)
            navigationHistory.Peek().CurrentControl.Invoke();
    }

    public void ChangeNavigation(GUINavigableControlGroup navigation)
    {
        if (navigationHistory.Count > 0) 
            navigationHistory.Peek().Deactivate();

        navigation.Activate();
        navigationHistory.Push(navigation);
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