using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl5_CollectItems : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player") && txtInteractMsg != null)
        {
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
                if (itemTag == "Cert")
                {
                    gameManager.probeItemCollected = 1;
                    if (gameManager.txtInteractMsg != null)
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                    gameManager.txtInteractMsg.text = "What an outstanding person he is";
                    gameManager.heldItem = "Certificate";
                    this.gameObject.SetActive(false);
                }
                else if (itemTag == "Badge")
                {
                    gameManager.probeItemCollected = 1;
                    if (gameManager.txtInteractMsg != null)
                        txtInteractMsg.color = new Color32(235, 255, 79, 255);
                    gameManager.txtInteractMsg.text = "Oh? He’s a hall monitor? Well maybe, he can monitor me..";
                    gameManager.heldItem = "Badge";
                    this.gameObject.SetActive(false);
                }
            }
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if (txtInteractMsg != null)
                txtInteractMsg.text = "";
            txtInteractMsg.color = Color.black;
            if (txtQuestionUpdate != null)
                txtQuestionUpdate.text = "";
        }
    }
}
