using UnityEngine;

public class GUINavigableContentGroup : GUINavigableItemsGroup
{    
    public GUINavigableContentGroup(GUIContent[] contents) : base(contents)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Vector2 padding) : base(contents, padding)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Vector2 position, Vector2 size) : base(contents, position, size)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Vector2 position, Vector2 size, Vector2 padding) : base(contents, position, size, padding)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Vector2 position, Vector2 size, Orientation orientation) : base(contents, position, size, orientation)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Vector2 position, Vector2 size, Vector2 padding, Orientation orientation) : base(contents, position, size, padding, orientation)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Orientation orientation) : base(contents, orientation)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Vector2 padding, Orientation orientation) : base(contents, padding, orientation)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Rect rect) : base(contents, rect)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Rect rect, Vector2 padding) : base(contents, rect, padding)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Rect rect, Orientation orientation) : base(contents, rect, orientation)
    {
    }
    public GUINavigableContentGroup(GUIContent[] contents, Rect rect, Vector2 padding, Orientation orientation) : base(contents, rect, padding, orientation)
    {
    }

    public override void Render()
    {
        base.Render();

        float itemTop = position.y + padding.y;
        float itemLeft = position.x + padding.x;

        foreach (GUIContent item in items)
        {
            float itemWidth = (orientation == Orientation.Vertical) ? size.x - (padding.x * 2) : (size.x - (padding.x * 2)) / items.Length;
            float itemHeight = (orientation == Orientation.Vertical) ? (size.y - (padding.y * 2)) / items.Length : size.y - (padding.y * 2);
            
            item.Content(new Rect(itemLeft, itemTop, itemWidth, itemHeight));

            if (orientation == Orientation.Vertical)
                itemTop += itemHeight;
            else
                itemLeft += itemWidth;
        }
    }
}