using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class InteractedChar : MonoBehaviour
{
    public GameObject fadeOutCanvas; 
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    private int dialogState = 0;
    private bool interactionStarted = false;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtQuestionUpdate.color = Color.black;
            txtInteractMsg.text = "Press [E] to interact";
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E) && !interactionStarted)
            {
                dialogState = 1;
                interactionStarted = true;
                UpdateDialogText();
            }
            else if (interactionStarted && Input.GetKeyDown(KeyCode.Return))
            {
                dialogState++;
                UpdateDialogText();
                
                if (dialogState > 6)
                {
                    gameManager.isCharInteracted = true;
                }
            }
        }
    }

    void UpdateDialogText()
    {
        switch (dialogState)
        {
            case 1:
                txtInteractMsg.color = new Color32(235, 255, 79, 255); 
                txtInteractMsg.text = "I will confess my feelings to him!";
                break;
            case 2:
                txtInteractMsg.text = "ISAAC\nThat's new. You'll make the first move. I hope you don't get hurt though. How will you confess?";
                break;
            case 3:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "Probably a letter.";
                break;
            case 4:

                txtInteractMsg.text = "ISAAC\nThat's it? You can do better.";
                break;
            case 5:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "Oh, shut up. As if you can think of anything more I can do.";
                break;
            case 6:
                txtInteractMsg.text = "ISAAC\nMaybe give things he would like.";
                break;
            default:
                txtInteractMsg.text = "";
                break;
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (gameManager.isCharInteracted)
            {
                txtQuestionUpdate.color = Color.black;
                txtQuestionUpdate.text = "You have interacted with the character!";
                if (fadeOutCanvas != null)
                    fadeOutCanvas.SetActive(true);

                Invoke("LoadNextScene", 2f);
            }
            else
            {
                txtQuestionUpdate.color = Color.black;
                txtInteractMsg.text = "";
                txtQuestionUpdate.text = "";
                dialogState = 0;
                interactionStarted = false;
            }
        }
    }

    void LoadNextScene()
    {
        txtQuestionUpdate.text = "";
       txtInteractMsg.color = Color.black;
        txtInteractMsg.text = "Loading next level...";
        Invoke("LoadLevel", 2f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene("Level_2");
    }
}