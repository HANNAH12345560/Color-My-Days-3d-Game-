using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl4_CollectItems : MonoBehaviour
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
                if (itemTag == "Mop")
                {
                    txtInteractMsg.text = "I don’t think a mop is a proper gift";
                }
                else if (itemTag == "Flower")
                {
                    txtInteractMsg.text = "How pretty! I bet these flowers are colorful!";
                    this.gameObject.SetActive(false);
                    gameManager.isItemSeen = true;
                    txtQuestionUpdate.text = "Look for the door";
                }
                
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
