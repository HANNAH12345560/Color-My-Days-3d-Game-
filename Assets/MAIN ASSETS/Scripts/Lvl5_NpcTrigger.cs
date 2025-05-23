using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl5_NpcTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    private bool hasReceivedItem = false;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (gameManager.probeItemCollected > 0)
            {
                if (!hasReceivedItem)
                {
                    txtInteractMsg.text = "Press [E] to give the item.";
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
                string npcTag = gameObject.tag;

                if (gameManager.probeItemCollected == 0)
                {
                    if (hasReceivedItem)
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "Thank you for the item.";
                    }
                    else if (npcTag == "NPC1")
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "Can you help me find cield's certificate? It’s a rectangle.";
                    }
                    else if (npcTag == "NPC2")
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "Can you find my hall monitor badge? Ciel has one, it’s a circle.";
                    }
                }
                else
                {
                    if (hasReceivedItem)
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "Thank you for the item.";
                    }
                    else
                    {
                        bool correctItem = false;
                        if (npcTag == "NPC1" && gameManager.heldItem == "Certificate")
                        {
                            correctItem = true;
                        }
                        else if (npcTag == "NPC2" && gameManager.heldItem == "Badge")
                        {
                            correctItem = true;
                        }

                        if (correctItem)
                        {
                            gameManager.isItemGiven = true;
                            hasReceivedItem = true;
                            gameManager.probeItemCollected--;
                            txtInteractMsg.color = new Color32(235, 255, 79, 255);

                            if (npcTag == "NPC1")
                            {
                                txtInteractMsg.text = "Thank you, now, I can hang this in our classroom.";
                            }
                            else if (npcTag == "NPC2")
                            {
                                txtInteractMsg.text = "There we go! He can start his duty tomorrow!";
                            }

                            gameManager.characterGiven2 += 1;
                        }
                        else
                        {
                            txtInteractMsg.text = "Thank you...? But this is not what I’m looking for";
                            txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        }
                    }

                    if (gameManager.probeItemCollected == 0 && gameManager.characterGiven2 == 2)
                    {
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                        txtInteractMsg.text = "I’ve gathered enough information, I can go now.";
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
