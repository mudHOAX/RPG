using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    private Dictionary<string, Texture2D> characterPortraits = new Dictionary<string, Texture2D> { };
    Texture2D menuBackgroundTexture;
    Texture2D menuBoxTexture;

    public void OnGUI()
    {
        Vector2 menuResolution = new Vector2(1024, 768);
        
        GUI.Box(new Rect(0, 0, Screen.width, Screen.height), menuBackgroundTexture);

        // Characters
        float menuBoxLeft = (float)(Screen.width / 2 - Math.Floor(menuResolution.x / 2)) + 25;
        float characterBoxHeight = 150.0f;
        float characterBoxPaddingRight = 200.0f;
        float characterBoxWidth = menuResolution.x - characterBoxPaddingRight;

        GUIStyle nameStyle = new GUIStyle();
        nameStyle.fontSize = 25;
        nameStyle.normal.textColor = Color.white;

        for (int i = 0; i < PlayerManager.Instance.Party.Length; i++)
        {
            float characterBoxTop = (Screen.height / 2 - ((characterBoxHeight * 4) / 2)) + (characterBoxHeight * i);

            BaseCharacter character = PlayerManager.Instance.Party[i];

            GUI.Box(new Rect(menuBoxLeft, characterBoxTop, characterBoxWidth, characterBoxHeight), menuBoxTexture);
            GUI.Box(new Rect(menuBoxLeft + 20.0f, characterBoxTop, characterBoxHeight + 20.0f, characterBoxHeight), menuBoxTexture);

            Texture2D characterPortrait;
            if (characterPortraits.ContainsKey(character.Name))
                characterPortrait = characterPortraits[character.Name];
            else
            {
                characterPortrait = new Texture2D((int)characterBoxHeight, (int)characterBoxHeight);
                characterPortrait.LoadImage(character.Portrait);
                characterPortraits.Add(character.Name, characterPortrait);
            }
            
            if (character.BattleRow == BattleRow.Front)
                GUI.Box(new Rect(menuBoxLeft + 20.0f, characterBoxTop, characterBoxHeight, characterBoxHeight), characterPortrait);
            else
                GUI.Box(new Rect(menuBoxLeft + 40.0f, characterBoxTop, characterBoxHeight, characterBoxHeight), characterPortrait);
            
            float keyLabelLeft = menuBoxLeft + characterBoxHeight + 50;
            float valueLabelLeft = keyLabelLeft + 50;

            GUI.Label(new Rect(keyLabelLeft, characterBoxTop + 10.0f, 100, 30), character.Name, nameStyle);
            GUI.Label(new Rect(keyLabelLeft, characterBoxTop + 40.0f, 100, 25), "Level:");
            GUI.Label(new Rect(valueLabelLeft, characterBoxTop + 40.0f, 100, 25), string.Format("{0}", character.Level));
            GUI.Label(new Rect(keyLabelLeft, characterBoxTop + 100.0f, 100, 25), "HP:");
            GUI.Label(new Rect(valueLabelLeft, characterBoxTop + 100.0f, 100, 25), string.Format("{0} / {1}", character.CurrentHP, character.MaxHP));
            GUI.Label(new Rect(keyLabelLeft, characterBoxTop + 125.0f, 100, 25), "MP:");
            GUI.Label(new Rect(valueLabelLeft, characterBoxTop + 125.0f, 100, 25), string.Format("{0} / {1}", character.CurrentMP, character.MaxMP));

            float statsBoxLeft = valueLabelLeft + 75.0f;
            float statsBoxTop = characterBoxTop + 40.0f;
            float statsBoxWidth = characterBoxWidth - 350.0f;
            float statsBoxHeight = characterBoxHeight - 50.0f;
            GUI.Box(new Rect(statsBoxLeft, statsBoxTop, statsBoxWidth, statsBoxHeight), menuBoxTexture);

            GUI.Label(new Rect(statsBoxLeft + 10.0f, statsBoxTop + 10.0f, 75, 25), "Speed:");
            GUI.Label(new Rect(statsBoxLeft + 85.0f, statsBoxTop + 10.0f, 75, 25), string.Format("{0}", character.Stats.Speed));

            GUI.Label(new Rect(statsBoxLeft + 10.0f, statsBoxTop + 30.0f, 75, 25), "Strength:");
            GUI.Label(new Rect(statsBoxLeft + 85.0f, statsBoxTop + 30.0f, 75, 25), string.Format("{0}", character.Stats.Strength));

            GUI.Label(new Rect(statsBoxLeft + 10.0f, statsBoxTop + 50.0f, 75, 25), "Magic:");
            GUI.Label(new Rect(statsBoxLeft + 85.0f, statsBoxTop + 50.0f, 75, 25), string.Format("{0}", character.Stats.Magic));
            
            GUI.Label(new Rect(statsBoxLeft + 10.0f, statsBoxTop + 70.0f, 75, 25), "Spirit:");
            GUI.Label(new Rect(statsBoxLeft + 85.0f, statsBoxTop + 70.0f, 75, 25), string.Format("{0}", character.Stats.Spirit));

            GUI.Label(new Rect(statsBoxLeft + 170.0f, statsBoxTop + 30.0f, 75, 25), "Attack:");
            GUI.Label(new Rect(statsBoxLeft + 245.0f, statsBoxTop + 30.0f, 75, 25), string.Format("{0}", character.Stats.Attack));
            
            GUI.Label(new Rect(statsBoxLeft + 170.0f, statsBoxTop + 50.0f, 75, 25), "Defence:");
            GUI.Label(new Rect(statsBoxLeft + 245.0f, statsBoxTop + 50.0f, 75, 25), string.Format("{0}", character.Stats.Defence));

            GUI.Label(new Rect(statsBoxLeft + 330.0f, statsBoxTop + 40.0f, 75, 25), "MSt:");
            GUI.Label(new Rect(statsBoxLeft + 405.0f, statsBoxTop + 40.0f, 75, 25), string.Format("{0}/{1}", 0, 12));
        }

        // Main Menu
        float mainMenuLeft = menuBoxLeft + characterBoxWidth - 20;
        float mainMenuTop = (Screen.height / 2 - ((characterBoxHeight * 4) / 2)) - 20;
        float mainMenuWidth = menuResolution.x / 6.0f;
        float mainMenuHeight = 190.0f;
        GUI.Box(new Rect(mainMenuLeft, mainMenuTop, mainMenuWidth, mainMenuHeight), menuBoxTexture);

        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 10.0f, mainMenuWidth - 20.0f, 25), "Items");
        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 35.0f, mainMenuWidth - 20.0f, 25), "Abilities");
        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 60.0f, mainMenuWidth - 20.0f, 25), "Equipment");
        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 85.0f, mainMenuWidth - 20.0f, 25), "Status");
        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 110.0f, mainMenuWidth - 20.0f, 25), "Order");
        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 135.0f, mainMenuWidth - 20.0f, 25), "Cards");
        GUI.Label(new Rect(mainMenuLeft + 10.0f, mainMenuTop + 160.0f, mainMenuWidth - 20.0f, 25), "Config");

        // Time & Gil
        float subMenuLeft = mainMenuLeft;
        float subMenuTop = mainMenuTop + mainMenuHeight + 315.0f;
        float subMenuWidth = mainMenuWidth;
        float subMenuHeight = 70.0f;
        GUI.Box(new Rect(subMenuLeft, subMenuTop, subMenuWidth, subMenuHeight), menuBoxTexture);
        
        GUIStyle subMenuStyle = new GUIStyle();
        subMenuStyle.alignment = TextAnchor.MiddleRight;
        subMenuStyle.normal.textColor = Color.white;

        TimeSpan GameTime = PlayerManager.Instance.GameTime;
        GUI.Label(new Rect(subMenuLeft + 10.0f, subMenuTop + 10.0f, subMenuWidth - 20.0f, 25), string.Format("{0}:{1:00}:{2:00}", Math.Floor(GameTime.TotalHours), GameTime.Minutes, GameTime.Seconds), subMenuStyle);
        GUI.Label(new Rect(subMenuLeft + 10.0f, subMenuTop + 35.0f, subMenuWidth - 20.0f, 25), string.Format("{0}G", PlayerManager.Instance.AvailableGil), subMenuStyle);

        // Location
        float infoBoxLeft = subMenuLeft;
        float infoBoxTop = subMenuTop + subMenuHeight + 20.0f;
        float infoBoxWidth = subMenuWidth;
        float infoBoxHeight = 45.0f;
        GUI.Box(new Rect(infoBoxLeft, infoBoxTop, infoBoxWidth,  infoBoxHeight), menuBoxTexture);
        
        GUIStyle infoStyle = new GUIStyle();
        infoStyle.alignment = TextAnchor.MiddleCenter;
        infoStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(infoBoxLeft + 10.0f, infoBoxTop + 10.0f, infoBoxWidth - 20.0f, 25), "Hadris Basin", infoStyle);
    }
}
