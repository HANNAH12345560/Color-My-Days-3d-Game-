using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl3CollectDrink : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            txtInteractMsg.text = "Press [E] to pickup";
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player"))
        {
            if(Input.GetKey(KeyCode.E))
            {
                gameManager.drinkCollected += 1;
                gameManager.txtQuestionUpdate.text = "Does he likes this drink?";
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
