using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PickupManager : MonoBehaviour
{
    public static PickupManager Instance;

    public int totalItems = 3;
    private int collectedItems = 0;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateScoreUI();
    }

    public void CollectItem()
    {
        collectedItems++;
        UpdateScoreUI();

        if (collectedItems >= totalItems)
        {
            SceneManager.LoadScene("MissionSuccess");
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Objectives: " + collectedItems + " / " + totalItems;
        }
    }
}