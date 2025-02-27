using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            //audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public void PlayMusic()
    {
        audioSource.Play();
    }

    public void ChangeMusic(AudioClip newClip)
    {
        audioSource.clip = newClip;
        audioSource.Play();
    }
}
