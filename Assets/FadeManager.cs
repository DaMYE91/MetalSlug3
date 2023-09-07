using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeManager : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;
    public string sceneToLoad = "Mission5Space"; // 바뀌는 씬의 이름

    private bool isFading = false;

    private void Start()
    {
        // 시작 시 페이드 인
        StartFadeIn();
    }

    public void StartFadeIn()
    {
        if (!isFading)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        isFading = true;
        float alpha = 1.0f;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }

        // 페이드 인이 완료되면 7초 후 페이드 아웃 시작
        yield return new WaitForSeconds(7.0f);
        StartFadeOut();
    }

    public void StartFadeOut()
    {
        if (!isFading)
        {
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        isFading = true;
        float alpha = 0.0f;

        while (alpha < 1)
        {
            alpha += Time.deltaTime / fadeDuration;
            SetAlpha(alpha);
            yield return null;
        }

        // 페이드 아웃이 완료되면 지정된 씬으로 전환
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }

    private void SetAlpha(float alpha)
    {
        if (fadeImage != null)
        {
            Color color = fadeImage.color;
            color.a = alpha;
            fadeImage.color = color;
        }
    }
}
