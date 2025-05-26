using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lvl10_Dialogue1 : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    private int dialogState = 0;
    private bool interactionStarted = false;
    private bool playerInRange = false;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            playerInRange = true;

            if (!gameManager.isDia1Done)
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
            if (!gameManager.isDia1Done)
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

                    if (dialogState > 7)
                    {
                        gameManager.isDia1Done = true;
                        interactionStarted = false;
                        txtInteractMsg.text = "";
                        txtQuestionUpdate.text = "";
                        GameManager.Instance.isDia1Done = true;
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

            if (!gameManager.isDia1Done)
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
                txtQuestionUpdate.text = "Go on, confess now!";
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
                txtInteractMsg.text = "He's right there. Should I confess now?";
                break;
            case 2:
                txtInteractMsg.text = "ISAAC\nIt's up to you, Jisan. Nothing bad will happen if you confess.";
                break;
            case 3:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "You don't know that!";
                break;
            case 4:
                txtInteractMsg.text = "ISAAC\nYes, I don't know what will happen, but I do know you will be at peace once you confess.";
                break;
            case 5:
                txtInteractMsg.text = "ISAAC\nSo are you going to confess?";
                break;
            case 6:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "...";
                break;
            case 7:
                txtInteractMsg.color = new Color32(235, 255, 79, 255);
                txtInteractMsg.text = "Yes.";
                break;
            default:
                txtInteractMsg.text = "";
                txtQuestionUpdate.text = "";
                break;
        }
    }


}
