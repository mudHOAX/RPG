using UnityEngine;

public static class BattleManager
{
    private static bool battleInProgress = false;
    private static Battle currentBattle;

    public static bool BattleInProgress
    {
        get { return battleInProgress; }
        private set { battleInProgress = value; }
    }

    public static Battle CurrentBattle
    {
        get { return currentBattle; }
        set {
            if (value == null)
            {
                battleInProgress = false;
                currentBattle = null;
            }
            else
            {
                battleInProgress = true;
                currentBattle = value;
            }         
        }
    }

    public static void ShowMessage(string messageFormat, params object[] messageArgs)
    {
        ShowMessage(string.Format(messageFormat, messageArgs));
    }

    public static void ShowMessage(string message)
    {
        Debug.Log(message);
    }

    public static void Flee()
    {
        // Flee..
    }
}