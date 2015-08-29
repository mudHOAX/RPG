using UnityEngine;

public class GUINavigableControlGroup : GUINavigableItemsGroup
{
    public GUINavigableControlGroup(GUIControl[] controls) : base(controls)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Vector2 padding) : base(controls, padding)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Vector2 position, Vector2 size) : base(controls, position, size)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Vector2 position, Vector2 size, Vector2 padding) : base(controls, position, size, padding)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Vector2 position, Vector2 size, Orientation orientation) : base(controls, position, size, orientation)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Vector2 position, Vector2 size, Vector2 padding, Orientation orientation) : base(controls, position, size, padding, orientation)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Orientation orientation) : base(controls, orientation)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Vector2 padding, Orientation orientation) : base(controls, padding, orientation)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Rect rect) : base(controls, rect)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Rect rect, Vector2 padding) : base(controls, rect, padding)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Rect rect, Orientation orientation) : base(controls, rect, orientation)
    {
    }
    public GUINavigableControlGroup(GUIControl[] controls, Rect rect, Vector2 padding, Orientation orientation) : base(controls, rect, padding, orientation)
    {
    }
}