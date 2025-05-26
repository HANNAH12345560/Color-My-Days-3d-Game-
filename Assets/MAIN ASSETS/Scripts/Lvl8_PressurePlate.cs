using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Lvl8_PressurePlate : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    public bool isPlateActive = false;

    private void OnTriggerEnter(Collider actor)
    {
        if (isPlateActive)
        {
            if (actor.gameObject.CompareTag("PlateActivator") || actor.gameObject.CompareTag("Player"))
            {
                txtInteractMsg.text = "Thank you for moving the box!";
                Invoke("ClrMsg", 1.5f);
                gameManager.platesActive += 1;
            }
        }
    }

    private void OnTriggerExit(Collider actor)
    {
        
        if (isPlateActive)
        {
            if (actor.gameObject.CompareTag("PlateActivator") || actor.gameObject.CompareTag("Player"))
            {
                txtInteractMsg.text = "Why did you remove the box?";
                Invoke("ClrMsg", 1.5f);
                gameManager.platesActive -= 1;
            }
        }
    }

    void ClrMsg()
    {
        txtInteractMsg.text = "";
    }
}
