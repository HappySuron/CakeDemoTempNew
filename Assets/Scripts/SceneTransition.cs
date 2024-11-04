using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // Image для затемнения
    public float fadeDuration = 1f; // Длительность затемнения

    private void Start()
    {
        // Убедитесь, что Image полностью прозрачен при старте
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, 1);
            StartCoroutine(FadeIn());
        }
    }

    public void TransitionToScene(string sceneName)
    {
        if (fadeImage != null)
        {
            StartCoroutine(FadeOutAndLoadScene(sceneName));
        }
    }

    private IEnumerator FadeIn()
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = 1 - (timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 0);

        OSTManager _managerOSTInstance = OSTManager.Instance;
        _managerOSTInstance.PlaySound(0, p1:1, p2:1);
        SoundManager _managerSoundInstance = SoundManager.Instance;
        _managerSoundInstance.PlaySound(0, random:true, p1:1, p2:1);
        GameManagerScript _managerGameInstance = GameManagerScript.Instance;
        _managerGameInstance.StartGame();
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeImage.color = new Color(0, 0, 0, 1);
        SceneManager.LoadScene(sceneName);
    }
}
