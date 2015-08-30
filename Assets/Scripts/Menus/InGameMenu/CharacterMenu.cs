using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;

public class CharacterMenu : Menu
{
    public BaseCharacter CharacterInfo;
    private Stopwatch stopwatch = new Stopwatch();

    public override void Update()
    {
        if (!stopwatch.IsRunning || stopwatch.ElapsedMilliseconds > 300)
        {
            stopwatch.Reset();
            stopwatch.Start();

            List<BaseCharacter> characters = PlayerManager.Instance.Party.ToList();
            if (Input.GetButton("PS4_L2"))
                characters.Reverse();

            if (Input.GetButton("PS4_L2") || Input.GetButton("PS4_R2"))
            {
                SoundManager.PlaySoundEffect(SoundEffects.Cursor);
                CharacterInfo = characters.SkipWhile(c => c.Name != CharacterInfo.Name).Skip(1).FirstOrDefault();
                if (CharacterInfo == null)
                    CharacterInfo = characters.First();
            }
            else
                stopwatch.Stop();
        }
        
        base.Update();
    }
}