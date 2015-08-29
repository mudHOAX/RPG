using System.Collections.Generic;
using UnityEngine;

public class GUIItemsGroup
{
    public enum Orientation
    {
        Vertical,
        Horizontal
    }

    protected Orientation orientation = Orientation.Vertical;
    protected Vector2 position = new Vector2(0, 0);
    protected Vector2 padding = new Vector2(0, 0);
    protected Vector2 size = new Vector2(100, 100);
    protected GUIItem[] items;
    protected List<Rect> itemPositions = new List<Rect> { };
    protected Texture2D texture;
    
    public GUIItemsGroup(GUIItem[] items)
    {
        this.items = items;
    }
    public GUIItemsGroup(GUIItem[] items, Vector2 padding) : this(items)
    {
        this.padding = padding;
    }
    public GUIItemsGroup(GUIItem[] items, Vector2 position, Vector2 size) : this(items)
    {
        this.position = position;
        this.size = size;
    }
    public GUIItemsGroup(GUIItem[] items, Vector2 position, Vector2 size, Vector2 padding) : this(items, position, size)
    {
        this.padding = padding;
    }
    public GUIItemsGroup(GUIItem[] items, Vector2 position, Vector2 size, Orientation orientation) : this(items, position, size)
    {
        this.orientation = orientation;
    }
    public GUIItemsGroup(GUIItem[] items, Vector2 position, Vector2 size, Vector2 padding, Orientation orientation) : this(items, position, size, padding)
    {
        this.orientation = orientation;
    }
    public GUIItemsGroup(GUIItem[] items, Orientation orientation) : this(items)
    {
        this.orientation = orientation;
    }
    public GUIItemsGroup(GUIItem[] items, Vector2 padding, Orientation orientation) : this(items, padding)
    {
        this.orientation = orientation;
    }
    public GUIItemsGroup(GUIItem[] items, Rect rect) : this(items, rect.position, rect.size)
    {
    }
    public GUIItemsGroup(GUIItem[] items, Rect rect, Vector2 padding) : this(items, rect)
    {
        this.padding = padding;
    }
    public GUIItemsGroup(GUIItem[] items, Rect rect, Orientation orientation) : this(items, rect)
    {
        this.orientation = orientation;
    }
    public GUIItemsGroup(GUIItem[] items, Rect rect, Vector2 padding, Orientation orientation) : this(items, rect, padding)
    {
        this.orientation = orientation;
    }

    public virtual void Start()
    {
        float itemTop = position.y + padding.y;
        float itemLeft = position.x + padding.x;

        foreach (GUIItem item in items)
        {
            float itemWidth = (orientation == Orientation.Vertical) ? size.x - (padding.x * 2) : (size.x - (padding.x * 2)) / items.Length;
            float itemHeight = (orientation == Orientation.Vertical) ? (size.y - (padding.y * 2)) / items.Length : size.y - (padding.y * 2);

            itemPositions.Add(new Rect(itemLeft, itemTop, itemWidth, itemHeight));

            if (orientation == Orientation.Vertical)
                itemTop += itemHeight;
            else
                itemLeft += itemWidth;
        }
    }

    public virtual void Render()
    {
        if (itemPositions.Count == 0)
            Start();

        GUI.Box(new Rect(position, size), texture);
        
        for (int i = 0; i < items.Length; i++)
        {
            GUIItem item = items[i];
            GUI.SetNextControlName(item.Name);
            if (item as GUIControl != null)
                GUI.Button(itemPositions[i], ((GUIControl)item).Label);
        }
    }
}