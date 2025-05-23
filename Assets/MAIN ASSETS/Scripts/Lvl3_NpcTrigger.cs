using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl3_NpcTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    private bool hasReceivedDrink = false;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (gameManager.drinkCollected > 0)
            {
                if (!hasReceivedDrink)
                {
                    txtInteractMsg.text = "Press [E] to give the drink.";
                }
                else
                {
                    txtInteractMsg.text = "Press [E] to interact.";
                }
            }
            else
            {
                txtInteractMsg.text = "Press [E] to interact.";
            }
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (gameManager.drinkCollected == 0)
                {
                    txtInteractMsg.color = new Color32(235, 255, 79, 255);
                    txtInteractMsg.text = "Get back to your seat! … I'm parched.";
                }
                else
                {
                    string npcTag = gameObject.tag;
                    
                    // Check if this NPC already has a drink
                    if (hasReceivedDrink)
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "Thank you, I already have a drink!";
                    }
                    else if (npcTag == "NPC1")
                    {
                        gameManager.isDrinkGiven = true;
                        hasReceivedDrink = true;
                        gameManager.drinkCollected--;
                        txtInteractMsg.text = "Thank you!";
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        gameManager.characterGiven += 1;
                    }
                    else if (npcTag == "NPC2")
                    {
                        gameManager.isDrinkGiven = true;
                        hasReceivedDrink = true;
                        gameManager.drinkCollected--;
                        txtInteractMsg.text = "Thank you!";
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        gameManager.characterGiven += 1;
                    }

                    if (gameManager.drinkCollected == 0 && gameManager.characterGiven == 2)
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "Do you want to go out? Sure! Thank you for the drink. Ciel was right, that drink is delicious.";
                        txtQuestionUpdate.text = "Look for the door";
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "";
            txtInteractMsg.color = Color.black;
            txtQuestionUpdate.text = "";
        }
    }
}
