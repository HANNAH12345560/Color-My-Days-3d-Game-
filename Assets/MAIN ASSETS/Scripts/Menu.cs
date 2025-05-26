using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject fadeOutCanvas; // Assign your FadeOut Canvas in the Inspector

    public void BtnStart()
    {
        if (fadeOutCanvas != null)
            fadeOutCanvas.SetActive(true); // Enable the FadeOut Canvas

        Invoke("LoadLevel1", 2f); // Wait for the animation to finish before loading
    }

    void LoadLevel1()
    {
        Destroy(fadeOutCanvas);
        SceneManager.LoadScene("Level_1");
    }

    public void BtnQuit()
    {
        Application.Quit();
    }
}
