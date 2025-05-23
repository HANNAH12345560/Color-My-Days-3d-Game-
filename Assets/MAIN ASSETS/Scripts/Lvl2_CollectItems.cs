using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Lvl2_CollectItems : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtQuestionUpdate.color = Color.black;
            txtInteractMsg.text = "Press [E] to pickup";
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {

            if (Input.GetKey(KeyCode.E))
            {
                string itemTag = gameObject.tag;

                if (itemTag == "Paper")
                {
                    gameManager.hasPaper = true;
                    gameManager.ItemCollected("Paper"); // Call the new method
                }
                else if (itemTag == "Envelope")
                {
                    gameManager.hasEnvelope = true;
                    gameManager.ItemCollected("Envelope"); // Call the new method
                }
                else if (itemTag == "Pencil")
                {
                    gameManager.hasPencil = true;
                    gameManager.ItemCollected("Pencil"); // Call the new method
                }

                // Don't increment itemsCollected here, it's done in the ItemCollected method
                this.gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "";
            txtQuestionUpdate.text = "";
        }
    }
}
