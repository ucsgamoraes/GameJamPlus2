using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource soundEffectSource;
    public AudioSource musicSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        soundEffectSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip soundClip)
    {
        soundEffectSource.PlayOneShot(soundClip);
    }

    public void PlayMusic(AudioClip musicClip)
    {
        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }

        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}