using System.Diagnostics;
using UnityEngine;

public class GUINavigableControlGroup : GUIControlGroup
{
    private Stopwatch stopwatch = new Stopwatch();
    private int currentControlIdx = 0;
    private bool isActive = false;

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

    public GUIControl CurrentControl { get { return controls[currentControlIdx]; } }

    public void Activate()
    {
        isActive = true;
        GUI.FocusControl(controls[0].Name);
    }

    public void Deactivate()
    {
        isActive = false;
    }

    public override void Render()
    {
        if (isActive)
        {
            float axis = (orientation == Orientation.Vertical) ? Input.GetAxis("Vertical") : -Input.GetAxis("Horizontal");

            if (!stopwatch.IsRunning || stopwatch.ElapsedMilliseconds > 300)
            {
                stopwatch.Reset();
                stopwatch.Start();

                if (axis > 0)
                    currentControlIdx--;
                else if (axis < 0)
                    currentControlIdx++;
                else if (axis == 0)
                    stopwatch.Stop();

                currentControlIdx = Mathf.Clamp(currentControlIdx, 0, controls.Length - 1);
            }
            GUI.FocusControl(CurrentControl.Name);
        }

        base.Render();
    }
}