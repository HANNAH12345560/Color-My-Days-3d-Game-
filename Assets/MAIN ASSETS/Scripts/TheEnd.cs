using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TheEnd : MonoBehaviour
{
    public GameManager gameManager;

    public void Start()
    {
        Invoke("LoadMenu", 3f);
    }
    
    void LoadMenu()
    {
        Time.timeScale = 1; 
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        GameObject fadeOut = GameObject.Find("FadeOutCanvas"); // Optional: only if it exists
        if (fadeOut != null)
            Destroy(fadeOut);
        SceneManager.LoadScene("MainMenu");
    }
}
