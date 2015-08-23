using System.Diagnostics;
using UnityEngine;

public class GUIControlGroup
{
    public enum Orientation
    {
        Vertical,
        Horizontal
    }

    protected Orientation orientation = Orientation.Vertical;
    private Vector2 position = new Vector2(0, 0);
    private Vector2 padding = new Vector2(0, 0);
    private Vector2 size = new Vector2(100, 100);
    protected GUIControl[] controls;
    private Texture2D texture;
    
    public GUIControlGroup(GUIControl[] controls)
    {
        this.controls = controls;
    }
    public GUIControlGroup(GUIControl[] controls, Vector2 padding) : this(controls)
    {
        this.padding = padding;
    }
    public GUIControlGroup(GUIControl[] controls, Vector2 position, Vector2 size) : this(controls)
    {
        this.position = position;
        this.size = size;
    }
    public GUIControlGroup(GUIControl[] controls, Vector2 position, Vector2 size, Vector2 padding) : this(controls, position, size)
    {
        this.padding = padding;
    }
    public GUIControlGroup(GUIControl[] controls, Vector2 position, Vector2 size, Orientation orientation) : this(controls, position, size)
    {
        this.orientation = orientation;
    }
    public GUIControlGroup(GUIControl[] controls, Vector2 position, Vector2 size, Vector2 padding, Orientation orientation) : this(controls, position, size, padding)
    {
        this.orientation = orientation;
    }
    public GUIControlGroup(GUIControl[] controls, Orientation orientation) : this(controls)
    {
        this.orientation = orientation;
    }
    public GUIControlGroup(GUIControl[] controls, Vector2 padding, Orientation orientation) : this(controls, padding)
    {
        this.orientation = orientation;
    }
    public GUIControlGroup(GUIControl[] controls, Rect rect) : this(controls, rect.position, rect.size)
    {
    }
    public GUIControlGroup(GUIControl[] controls, Rect rect, Vector2 padding) : this(controls, rect)
    {
        this.padding = padding;
    }
    public GUIControlGroup(GUIControl[] controls, Rect rect, Orientation orientation) : this(controls, rect)
    {
        this.orientation = orientation;
    }
    public GUIControlGroup(GUIControl[] controls, Rect rect, Vector2 padding, Orientation orientation) : this(controls, rect, padding)
    {
        this.orientation = orientation;
    }
    
    public virtual void Render()
    {
        GUI.Box(new Rect(position, size), texture);

        float controlTop = position.y + padding.y;
        float controlLeft = position.x + padding.x;
        
        foreach (GUIControl control in controls)
        {
            float controlWidth = (orientation == Orientation.Vertical) ? size.x - (padding.x * 2) : (size.x - (padding.x * 2)) / controls.Length;
            float controlHeight = (orientation == Orientation.Vertical) ? (size.y - (padding.y * 2)) / controls.Length : size.y - (padding.y * 2);

            GUI.SetNextControlName(control.name);
            GUI.Button(new Rect(controlLeft, controlTop, controlWidth, controlHeight), control.label);

            if (orientation == Orientation.Vertical)
                controlTop += controlHeight;
            else
                controlLeft += controlWidth;
        }
    }
}