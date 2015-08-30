using System;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : Menu
{
    private Dictionary<string, Texture2D> characterPortraits = new Dictionary<string, Texture2D> { };
    private List<GUIControl> controls;

    private GUINavigableContentGroup characterMenu;
    private List<GUIContent> characters;

    public override void OnGUI()
    {
        base.OnGUI();

        if (controls == null)
            controls = new List<GUIControl>
            {
                new GUIControl { Name = "menu-items", Label = "Items", Action = () => { MenuManager.LoadMenu<ItemMenu>(); } },
                new GUIControl { Name = "menu-abilities", Label = "Abilities", Action = () => 
                {
                    ChangeNavigation(characterMenu);
                }},
                new GUIControl { Name = "menu-equipment", Label = "Equipment", Action = () => 
                {
                    ChangeNavigation(characterMenu);
                }},
                new GUIControl { Name = "menu-status", Label = "Status", Action = () => 
                {
                    ChangeNavigation(characterMenu);
                }},
                new GUIControl { Name = "menu-order", Label = "Order", Action = () => 
                {
                    ChangeNavigation(characterMenu);
                }},
                new GUIControl { Name = "menu-cards", Label = "Cards", Action = () => { /*MenuManager.LoadMenu<CardsMenu>();*/ } },
                new GUIControl { Name = "menu-config", Label = "Config", Action = () => { /*MenuManager.LoadMenu<ConfigMenu>();*/ } }
            };
        
        GUIStyle nameStyle = new GUIStyle();
        nameStyle.fontSize = 25;
        nameStyle.normal.textColor = Color.white;

        if (characters == null)
        {
            characters = new List<GUIContent>();
            for (int i = 0; i < PlayerManager.Instance.Party.Length; i++)
            {
                BaseCharacter character = PlayerManager.Instance.Party[i];
                characters.Add(
                    new GUIContent {
                        Name = string.Format("char-{0}", character.Name),
                        Content = (Rect position) =>
                        {
                            GUI.Box(new Rect(position.xMin, position.yMin, position.width, position.height), menuBoxTexture);
                            GUI.Box(new Rect(position.xMin + 20.0f, position.yMin, position.height + 20.0f, position.height), menuBoxTexture);

                            Texture2D characterPortrait;
                            if (characterPortraits.ContainsKey(character.Name))
                                characterPortrait = characterPortraits[character.Name];
                            else
                            {
                                characterPortrait = new Texture2D((int)position.height, (int)position.height);
                                characterPortrait.LoadImage(character.Portrait);
                                characterPortraits.Add(character.Name, characterPortrait);
                            }

                            if (character.BattleRow == BattleRow.Front)
                                GUI.Box(new Rect(position.xMin + 20.0f, position.yMin, position.height, position.height), characterPortrait);
                            else
                                GUI.Box(new Rect(position.xMin + 40.0f, position.yMin, position.height, position.height), characterPortrait);

                            float keyLabelLeft = position.xMin + position.height + 50;
                            float valueLabelLeft = keyLabelLeft + 50;

                            GUI.Label(new Rect(keyLabelLeft, position.yMin + 10.0f, 100, 30), character.Name, nameStyle);
                            GUI.Label(new Rect(keyLabelLeft, position.yMin + 40.0f, 100, 25), "Level:");
                            GUI.Label(new Rect(valueLabelLeft, position.yMin + 40.0f, 100, 25), string.Format("{0}", character.Level));
                            GUI.Label(new Rect(keyLabelLeft, position.yMin + 100.0f, 100, 25), "HP:");
                            GUI.Label(new Rect(valueLabelLeft, position.yMin + 100.0f, 100, 25), string.Format("{0} / {1}", character.CurrentHP, character.MaxHP));
                            GUI.Label(new Rect(keyLabelLeft, position.yMin + 125.0f, 100, 25), "MP:");
                            GUI.Label(new Rect(valueLabelLeft, position.yMin + 125.0f, 100, 25), string.Format("{0} / {1}", character.CurrentMP, character.MaxMP));

                            float statsBoxLeft = valueLabelLeft + 75.0f;
                            float statsBoxTop = position.yMin + 40.0f;
                            float statsBoxWidth = position.width - 350.0f;
                            float statsBoxHeight = position.height - 50.0f;
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
                        },
                        Action = () => {
                            switch (primaryNavigation.CurrentItem.Name)
                            {
                                case "menu-abilities":
                                    MenuManager.LoadMenu<AbilitiesMenu>(character);
                                    break;
                                case "menu-equipment":
                                    MenuManager.LoadMenu<EquipmentMenu>(character);
                                    break;
                                case "menu-status":
                                    MenuManager.LoadMenu<StatusMenu>(character);
                                    break;
                                case "menu-order":
                                    character.BattleRow = (character.BattleRow == BattleRow.Front) ? BattleRow.Back : BattleRow.Front;
                                    break;
                            }
                        }
                });
            }
        }
        
        // Characters
        float menuBoxLeft = (float)(Screen.width / 2 - Math.Floor(menuResolution.x / 2)) + 25;
        float characterBoxHeight = 150.0f;
        float characterBoxPaddingRight = 200.0f;
        float characterBoxWidth = menuResolution.x - characterBoxPaddingRight;

        if (characterMenu == null)
            characterMenu = new GUINavigableContentGroup(characters.ToArray(), new Rect(menuBoxLeft, Screen.height / 2 - ((characterBoxHeight * 4) / 2), characterBoxWidth, characterBoxHeight * 4), GUIItemsGroup.Orientation.Vertical);
        characterMenu.Render();

        // Main Menu
        float mainMenuLeft = menuBoxLeft + characterBoxWidth - 20;
        float mainMenuTop = (Screen.height / 2 - ((characterBoxHeight * 4) / 2)) - 20;
        float mainMenuWidth = menuResolution.x / 6.0f;
        float mainMenuHeight = 195.0f;

        if (PrimaryNavigation == null)
            PrimaryNavigation = new GUINavigableControlGroup(controls.ToArray(), new Rect(mainMenuLeft, mainMenuTop, mainMenuWidth, mainMenuHeight), new Vector2(10, 10));
        PrimaryNavigation.Render();

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