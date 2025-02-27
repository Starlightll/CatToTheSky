using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;
    public Image fadePanel;
    public float fadeDuration = 3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(1));
    }

    IEnumerator FadeIn()
    {
        yield return Fade(0);
    }

    IEnumerator Fade(float targetAlpha)
    {
        float startAlpha = fadePanel.color.a;
        float time = 0;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, time / fadeDuration);
            fadePanel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadePanel.color = new Color(0, 0, 0, targetAlpha);
    }
}
