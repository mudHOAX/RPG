using System.Diagnostics;
using System.IO;
using UnityEngine;

public abstract class GUINavigableItemsGroup : GUIItemsGroup
{
    private Texture2D cursor;
    private Rect cursorPosition;
    private Stopwatch stopwatch = new Stopwatch();
    protected int currentControlIdx = 0;
    protected bool isActive = false;
    public bool isPrimary = false;

    public GUINavigableItemsGroup(GUIItem[] items) : base(items)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Vector2 padding) : base(items, padding)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Vector2 position, Vector2 size) : base(items, position, size)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Vector2 position, Vector2 size, Vector2 padding) : base(items, position, size, padding)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Vector2 position, Vector2 size, Orientation orientation) : base(items, position, size, orientation)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Vector2 position, Vector2 size, Vector2 padding, Orientation orientation) : base(items, position, size, padding, orientation)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Orientation orientation) : base(items, orientation)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Vector2 padding, Orientation orientation) : base(items, padding, orientation)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Rect rect) : base(items, rect)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Rect rect, Vector2 padding) : base(items, rect, padding)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Rect rect, Orientation orientation) : base(items, rect, orientation)
    {
    }
    public GUINavigableItemsGroup(GUIItem[] items, Rect rect, Vector2 padding, Orientation orientation) : base(items, rect, padding, orientation)
    {
    }

    public GUIItem CurrentItem { get { return items[currentControlIdx]; } }

    public void Activate()
    {
        isActive = true;
        GUI.FocusControl(items[0].Name);
    }

    public void Deactivate()
    {
        isActive = false;
    }

    public override void Start()
    {
        base.Start();

        cursor = new Texture2D(50, 50);
        cursor.LoadImage(File.ReadAllBytes("Assets/Textures/GUI/Cursor.png"));
    }

    public override void Render()
    {
        base.Render();

        if (isActive)
        {
            float axis = (orientation == Orientation.Vertical) ? Input.GetAxis("Vertical") : -Input.GetAxis("Horizontal");

            if (!stopwatch.IsRunning || stopwatch.ElapsedMilliseconds > 300)
            {
                stopwatch.Reset();
                stopwatch.Start();

                if (axis > 0)
                {
                    currentControlIdx--;
                }
                else if (axis < 0)
                    currentControlIdx++;
                else if (axis == 0)
                    stopwatch.Stop();

                currentControlIdx = Mathf.Clamp(currentControlIdx, 0, items.Length - 1);
            }
            GUI.FocusControl(CurrentItem.Name);
        }

        if (isActive || isPrimary)
        {
            int cursorWidth = 48;
            int cursorHeight = 24;
            cursorPosition = new Rect(itemPositions[currentControlIdx]);
            cursorPosition.Set(cursorPosition.xMin - cursorWidth + 5, cursorPosition.yMin + 5, cursorWidth, cursorHeight);
            GUI.DrawTexture(cursorPosition, cursor);
        }
    }
}