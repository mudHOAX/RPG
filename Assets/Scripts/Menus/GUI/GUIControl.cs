using System;

public class GUIControl
{
    public string Name;
    public string Label;
    public Action Action;

    public void Invoke()
    {
        Action.Invoke();
    }
}