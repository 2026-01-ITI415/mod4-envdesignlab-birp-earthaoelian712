using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GameOverZone : MonoBehaviour
{
    public string gameOverSceneName = "GameOver";
    public float countdownTime = 5f;

    public TextMeshProUGUI warningText;
    public Image redFlashImage;

    private Coroutine countdownCoroutine;

    private void Start()
    {
        if (warningText != null)
            warningText.gameObject.SetActive(false);

        if (redFlashImage != null)
            redFlashImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && countdownCoroutine == null)
        {
            countdownCoroutine = StartCoroutine(GameOverCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (countdownCoroutine != null)
            {
                StopCoroutine(countdownCoroutine);
                countdownCoroutine = null;
            }

            if (warningText != null)
                warningText.gameObject.SetActive(false);

            if (redFlashImage != null)
                redFlashImage.gameObject.SetActive(false);
        }
    }

    private IEnumerator GameOverCountdown()
    {
        float timer = countdownTime;

        if (warningText != null)
            warningText.gameObject.SetActive(true);

        if (redFlashImage != null)
            redFlashImage.gameObject.SetActive(true);

        while (timer > 0)
        {
            if (warningText != null)
            {
                warningText.text = "Warning! Leave the danger zone!\nGame Over in " + Mathf.Ceil(timer);
            }

            if (redFlashImage != null)
            {
                float alpha = Mathf.PingPong(Time.time * 2f, 0.35f);
                Color c = redFlashImage.color;
                c.a = alpha;
                redFlashImage.color = c;
            }

            yield return null;
            timer -= Time.deltaTime;
        }

        SceneManager.LoadScene(gameOverSceneName);
    }
}