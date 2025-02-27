using System.Collections;
using UnityEngine;

public class AudioFadeInOut : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioSource audioSource;
    public float fadeDuration = 1.5f; // Thời gian fade (giây)

    private void Start()
    {
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void FadeIn()
    {
        StartCoroutine(FadeAudio(0f, 1f)); // Fade từ 0 lên 1 (max volume)
    }

    public void FadeOut()
    {
        StartCoroutine(FadeAudio(1f, 0f)); // Fade từ 1 xuống 0 (mute)
    }

    private IEnumerator FadeAudio(float startVolume, float targetVolume)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / fadeDuration);
            yield return null;
        }

        audioSource.volume = targetVolume;

        // Nếu FadeOut xong thì dừng nhạc
        if (targetVolume == 0f)
        {
            audioSource.Stop();
        }
    }
}
