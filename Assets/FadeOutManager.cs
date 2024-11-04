using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutManager : MonoBehaviour
{
    public static FadeOutManager Instance;

    public Image fadeImage; // UI Image для затемнения экрана

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

    public void StartFadeOut(float duration)
    {
        StartCoroutine(FadeOut(duration));
    }

    private IEnumerator FadeOut(float duration)
    {
        Color fadeColor = fadeImage.color;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            fadeColor.a = Mathf.Clamp01(elapsedTime / duration);
            fadeImage.color = fadeColor;
            yield return null;
        }
    }
}
