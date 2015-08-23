using UnityEngine;

public class AbilitiesMenu : CharacterMenu
{
    public void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 500), string.Format("Abilities for {0}", CharacterInfo.Name));
    }
}