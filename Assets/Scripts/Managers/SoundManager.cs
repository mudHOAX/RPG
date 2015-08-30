using UnityEngine;

public enum SoundEffects
{
    Cursor,
    CursorCancel,
    CursorError
}

public class SoundManager : MonoBehaviour
{
    private AudioSource soundEffectAudioSource;
    private AudioSource backgroundAudioSource;

    public AudioClip SoundEffectCursor;
    public AudioClip SoundEffectCursorCancel;
    public AudioClip SoundEffectCursorError;

    public AudioClip ThemeSong;

    public static SoundManager Instance { get; private set; }

    public void Start()
    {
        soundEffectAudioSource = gameObject.AddComponent<AudioSource>();
        backgroundAudioSource = gameObject.AddComponent<AudioSource>();
        Instance = this;

        backgroundAudioSource.clip = ThemeSong;
        backgroundAudioSource.loop = true;
        backgroundAudioSource.Play();
    }

    public static void PlaySoundEffect(SoundEffects effect)
    {
        switch (effect)
        {
            case SoundEffects.Cursor:
                Instance.soundEffectAudioSource.PlayOneShot(Instance.SoundEffectCursor);
                break;
            case SoundEffects.CursorCancel:
                Instance.soundEffectAudioSource.PlayOneShot(Instance.SoundEffectCursorCancel);
                break;
            case SoundEffects.CursorError:
                Instance.soundEffectAudioSource.PlayOneShot(Instance.SoundEffectCursorError);
                break;

        }
    }
}