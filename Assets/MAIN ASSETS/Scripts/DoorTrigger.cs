using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class DoorTrigger : MonoBehaviour
{
    public GameObject fadeOutCanvas;
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    [Header("Level 9 Door")]
    public int Level9DoorID;
    public bool isLevel9CorrectDoor; //referenced to level 9, identifies correct door
                                     
   
      

       




    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (gameManager != null && gameManager.levelAt == 6)
            {
                // Do NOT show "Press [E] to interact", and trigger logic automatically
                gameManager.isGameWon = true;
                txtInteractMsg.text = "Successfully survived!";
                txtQuestionUpdate.text = "Loading next level...";
                Invoke("LoadLevel7", 2f);
            }
            else
            {
                txtInteractMsg.text = "Press [E] to interact";
            }
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            // Only allow E for levels other than 6
            if (Input.GetKeyDown(KeyCode.E) && gameManager != null && gameManager.levelAt != 6)
            {
                switch (gameManager.levelAt)
                {
                    case 1:
                        if (!gameManager.isCharInteracted)
                        {
                            txtQuestionUpdate.text = "Maybe I should tell Isaac about my plan";
                        }
                        break;
                    case 2:
                        if (gameManager.itemsCollected < 3)
                        {
                            int missingItems = 3 - gameManager.itemsCollected;

                            if (missingItems == 1)
                            {
                                if (!gameManager.hasPaper)
                                {
                                    txtQuestionUpdate.text = "Scented paper is perfect for a confession! I can't see colors but I'll still be able to give him an aromatic experience!";
                                }
                                else if (!gameManager.hasPencil)
                                {
                                    txtQuestionUpdate.text = "How can I write a letter without a pen? Silly me.";
                                }
                                else if (!gameManager.hasEnvelope)
                                {
                                    txtQuestionUpdate.text = "Envelope to seal off the confession and he will open the start of our love story.";
                                }
                            }
                            else
                            {
                                txtQuestionUpdate.text = "I should collect all the items first";
                            }
                        }
                        else
                        {
                            if (fadeOutCanvas != null)
                                fadeOutCanvas.SetActive(true);

                            txtQuestionUpdate.text = "Loading next level...";
                            Invoke("LoadLevel3", 2f);
                        }
                        break;

                    case 3:
                        if (gameManager.drinkCollected <= 2 && gameManager.characterGiven < 2)
                        {
                            txtInteractMsg.color = new Color32(235, 255, 79, 255);
                            txtInteractMsg.text = "Hey you! you can't just leave. God, I'm thirsty.";
                        }
                        else if (gameManager.characterGiven == 2)
                        {
                            if (fadeOutCanvas != null)
                                fadeOutCanvas.SetActive(true);

                            txtQuestionUpdate.text = "Loading next level...";
                            Invoke("LoadLevel4", 2f);
                        }
                        break;

                    case 4:
                        if (!gameManager.isItemSeen)
                        {
                            txtQuestionUpdate.text = "I still need something from this room";
                        }
                        else
                        {
                            if (fadeOutCanvas != null)
                                fadeOutCanvas.SetActive(true);

                            txtQuestionUpdate.text = "Loading next level...";
                            Invoke("LoadLevel5", 2f);
                        }
                        break;
                    case 5:
                        if (gameManager.probeItemCollected <= 2 && gameManager.characterGiven2 < 2)
                        {
                            txtInteractMsg.color = Color.black;
                            txtInteractMsg.text = "I still need to gather information.";
                        }
                        else if (gameManager.characterGiven2 == 2)
                        {
                            if (fadeOutCanvas != null)
                                fadeOutCanvas.SetActive(true);

                            txtQuestionUpdate.text = "Loading next level...";
                            Invoke("LoadLevel6", 2f);
                        }
                        break;
                    case 7:
                        break;
                    case 9:
                        if (Level9DoorID == 0)
                        {
                            txtInteractMsg.text = "Seems peaceful.";
                        }
                        else if (Level9DoorID == 1)
                        {
                            txtInteractMsg.text = "Kinda Noisy.";
                        }
                        else if (Level9DoorID == 2)
                        {
                            txtInteractMsg.text = "Feels refreshing.";
                        }
                        if (Level9DoorID == 2) // Right door is correct
                        {
                            if (fadeOutCanvas != null)
                                fadeOutCanvas.SetActive(true);

                                txtQuestionUpdate.text = "Loading next level...";
                                Invoke("LoadLevel10", 2f);
                           }

                           
                        else
                        {
                            if (fadeOutCanvas != null)
                                fadeOutCanvas.SetActive(true);

                            txtQuestionUpdate.text = "That was not the way to the rooftop.";
                            Invoke("RestartLevel9", 2f);
                        }
                        break;

                       

                }
            }
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.color = Color.black;
            txtInteractMsg.text = "";
            txtQuestionUpdate.text = "";
        }
    }

    void LoadLevel3()
    {
        SceneManager.LoadScene("Level_3");
    }

    void LoadLevel4()
    {
        SceneManager.LoadScene("Level_4");
    }

    void LoadLevel5()
    {
        SceneManager.LoadScene("Level_5");
    }

    void LoadLevel6()
    {
        SceneManager.LoadScene("Level_6");
    }

    void LoadLevel7()
    {
        SceneManager.LoadScene("Level_7");
    }
    void RestartLevel9()
    {
        SceneManager.LoadScene("Level_9");
    }

    void LoadLevel10()
    {
        SceneManager.LoadScene("Level_10");

    }
}


