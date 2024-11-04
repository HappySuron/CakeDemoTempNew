using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScreenFadeIn : MonoBehaviour
{
    public float fadeDuration = 2f;
    private Image fadeImage;

    private void Start()
    {
        fadeImage = GetComponent<Image>();
        if (fadeImage != null)
        {
            fadeImage.color = new Color(0, 0, 0, 1);
        }
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        fadeImage.color = new Color(0, 0, 0, 0);
        StartNextAction();
    }

    private void StartNextAction()
    {
        OSTManager _managerOSTInstance = OSTManager.Instance;
        _managerOSTInstance.PlaySound(0, p1:1, p2:1);
        SoundManager _managerSoundInstance = SoundManager.Instance;
        _managerSoundInstance.PlaySound(0, random:true, p1:1, p2:1);
        GameManagerScript _managerGameInstance = GameManagerScript.Instance;
        _managerGameInstance.StartGame();
    }
}
