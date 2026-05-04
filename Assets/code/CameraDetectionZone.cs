using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraDetectionZone : MonoBehaviour
{
    public float detectionTime = 2f;
    public bool cameraActive = true;

    private float timer = 0f;
    private bool playerInside = false;

    void Update()
    {
        if (!cameraActive)
            return;

        if (playerInside)
        {
            timer += Time.deltaTime;

            if (timer >= detectionTime)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (cameraActive && other.CompareTag("Player"))
        {
            playerInside = true;
            timer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            timer = 0f;
        }
    }

    public void DisableCamera()
    {
        cameraActive = false;
        gameObject.SetActive(false);
    }
}