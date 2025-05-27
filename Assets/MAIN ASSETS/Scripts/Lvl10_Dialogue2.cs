using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Lvl10_Dialogue2 : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    public GameObject fadeOutCanvas;

    private int dialogState = 0;
    private bool interactionStarted = false;
    private bool playerInRange = false;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            playerInRange = true;

            if (!GameManager.Instance.isDia1Done)
            {
                txtQuestionUpdate.text = "You must talk to Isaac first.";
                txtInteractMsg.text = "";
            }
            else if (!gameManager.isDia2Done)
            {
                txtQuestionUpdate.color = Color.black;
                txtInteractMsg.text = "Press [E] to interact";
            }
            else
            {
                txtInteractMsg.text = "";
            }
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player") && playerInRange)
        {

            if (!GameManager.Instance.isDia1Done)
                return;
            else if (!gameManager.isDia2Done)
            {
                if (Input.GetKeyDown(KeyCode.E) && !interactionStarted)
                {
                    dialogState = 1;
                    interactionStarted = true;
                    txtInteractMsg.text = "";
                    UpdateDialogText();
                }
                else if (interactionStarted && Input.GetKeyDown(KeyCode.Return))
                {
                    dialogState++;
                    UpdateDialogText();

                    if (dialogState > 9)
                    {
                        gameManager.isDia2Done = true;
                        interactionStarted = false;
                        txtInteractMsg.text = "";
                        txtQuestionUpdate.text = "";
                    }
                }
            }
            else
            {
                // Prevent re-interaction
                txtInteractMsg.text = "";
            }
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            playerInRange = false;

            if (!gameManager.isDia2Done)
            {
                txtQuestionUpdate.color = Color.black;
                txtInteractMsg.text = "";
                txtQuestionUpdate.text = "";
                dialogState = 0;
                interactionStarted = false;
            }
            else
            {
                txtQuestionUpdate.color = Color.black;
                txtInteractMsg.text = "";
                txtQuestionUpdate.text = "You've finally confessed and happily gay!";

                if (fadeOutCanvas != null)
                    fadeOutCanvas.SetActive(true);

                Invoke("TheEndScene", 5f);
            }
        }
    }

    void UpdateDialogText()
    {
        txtQuestionUpdate.text = "Press Enter to proceed.";

        switch (dialogState)
        {
            case 1:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "Ciel?";
                break;
            case 2:
                txtInteractMsg.text = "CIEL\nJisan! I haven't seen you for days, I've missed you!";
                break;
            case 3:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "I missed you too.";
                break;
            case 4:
                txtInteractMsg.text = "CIEL\nWhat's that on your hands?";
                break;
            case 5:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "It's a letter for you.";
                break;
            case 6:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "I like you, Ciel.";
                break;
            case 7:
                txtInteractMsg.text = "CIEL\nI like you too, Jisan. You've always felt important to me.";
                break;
            case 8:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "Really?";
                break;
            case 9:
                txtInteractMsg.text = "CIEL\nYes, Jisan. I wish to bring color to your life.";
                break;
            default:
                txtInteractMsg.text = "";
                txtQuestionUpdate.text = "";
                break;
        }
    }

    void TheEndScene()
    {
        if (fadeOutCanvas != null)
        Destroy(fadeOutCanvas);
        
        SceneManager.LoadScene("TheEnd");
    }
}