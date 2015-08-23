using UnityEngine;

public class EquipmentMenu : CharacterMenu
{
    public void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 500), string.Format("Equipment for {0}", CharacterInfo.Name));
    }
}