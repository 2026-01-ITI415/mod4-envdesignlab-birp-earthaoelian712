using UnityEngine;
using TMPro;

public class GeneratorSwitch : MonoBehaviour
{
    public CameraDetectionZone[] camerasToDisable;

    public GameObject promptText; // 👈 拖你的“Press E”文字

    private bool playerInside = false;
    private bool used = false;

    void Start()
    {
        if (promptText != null)
            promptText.SetActive(false); // 默认隐藏
    }

    void Update()
    {
        if (playerInside && !used && Input.GetKeyDown(KeyCode.E))
        {
            used = true;

            foreach (CameraDetectionZone cam in camerasToDisable)
            {
                if (cam != null)
                    cam.DisableCamera();
            }

            if (promptText != null)
                promptText.SetActive(false);

            Debug.Log("Security cameras disabled.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;

            if (!used && promptText != null)
                promptText.SetActive(true); // 👈 显示提示
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (promptText != null)
                promptText.SetActive(false); // 👈 离开隐藏
        }
    }
}