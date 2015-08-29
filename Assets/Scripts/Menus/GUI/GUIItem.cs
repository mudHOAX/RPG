using System;

public abstract class GUIItem
{
    public string Name;
    public Action Action;

    public void Invoke()
    {
        Action.Invoke();
    }
}