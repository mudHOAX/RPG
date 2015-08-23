using UnityEngine;

public class StatusMenu : CharacterMenu
{
    public void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 500), string.Format("Status for {0}", CharacterInfo.Name));
    }
}