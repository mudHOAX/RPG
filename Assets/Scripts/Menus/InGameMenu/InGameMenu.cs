using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class InGameMenu : Menu
{
    public Texture2D cursor = new Texture2D(20, 20);
    private Vector2 cursorPosition;
    private Stopwatch stopwatch = new Stopwatch();

    private Dictionary<string, Texture2D> characterPortraits = new Dictionary<string, Texture2D> { };
    Texture2D menuBackgroundTexture;
    Texture2D menuBoxTexture;
    int currentButton = 0;

    GUIButton[] menuButtons = new GUIButton[] {
        new GUIButton { controlName = "Items", text = "Items", action = () => { UnityEngine.Debug.Log("Items"); MenuManager.LoadMenu<ItemMenu>(); } },
        new GUIButton { controlName = "Abilities", text = "Abilities", action = () => { UnityEngine.Debug.Log("Abilities"); } },
        new GUIButton { controlName = "Equipment", text = "Equipment", action = () => { UnityEngine.Debug.Log("Equipment"); } },
        new GUIButton { controlName = "Status", text = "Status", action = () => { UnityEngine.Debug.Log("Status"); } },
        new GUIButton { controlName = "Order", text = "Order", action = () => { UnityEngine.Debug.Log("Order"); } },
        new GUIButton { controlName = "Cards", text = "Cards", action = () => { UnityEngine.Debug.Log("Cards"); } },
        new GUIButton { controlName = "Config", text = "Config", action = () => { UnityEngine.Debug.Log("Config"); } }
    };

    public void Update()
    {
        if (Input.GetButtonDown("PS4_Cross"))
            menuButtons[currentButton].action.Invoke();
    }

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
        float mainMenuHeight = 195.0f;
        GUI.Box(new Rect(mainMenuLeft, mainMenuTop, mainMenuWidth, mainMenuHeight), menuBoxTexture);

        float axis = Input.GetAxis("Vertical");

        if (!stopwatch.IsRunning || stopwatch.ElapsedMilliseconds > 300)
        {
            stopwatch.Reset();
            stopwatch.Start();

            if (axis > 0)
                currentButton--;
            else if (axis < 0)
                currentButton++;
            else if (axis == 0)
                stopwatch.Stop();

            currentButton = Mathf.Clamp(currentButton, 0, menuButtons.Length - 1);
        }


        float buttonLeft = mainMenuLeft + 10.0f;
        float buttonTop = mainMenuTop + 10.0f;
        foreach (GUIButton button in menuButtons)
        {
            GUI.SetNextControlName(button.controlName);
            if (GUI.Button(new Rect(buttonLeft, buttonTop, mainMenuWidth - 20.0f, 25), button.text))
                button.action.Invoke();

            buttonTop += 25.0f;
        }


        GUI.FocusControl(menuButtons[currentButton].controlName);

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
        GUI.Box(new Rect(infoBoxLeft, infoBoxTop, infoBoxWidth, infoBoxHeight), menuBoxTexture);

        GUIStyle infoStyle = new GUIStyle();
        infoStyle.alignment = TextAnchor.MiddleCenter;
        infoStyle.normal.textColor = Color.white;

        GUI.Label(new Rect(infoBoxLeft + 10.0f, infoBoxTop + 10.0f, infoBoxWidth - 20.0f, 25), "Hadris Basin", infoStyle);
    }
}