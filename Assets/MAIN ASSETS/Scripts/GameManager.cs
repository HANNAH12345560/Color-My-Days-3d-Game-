using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Level Info")]
    public int levelAt;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    [Header("Level 1")]
    public bool isCharInteracted = false;

    [Header("Level 2")]
    public int itemsCollected = 0;
    public bool hasPaper = false;
    public bool hasPencil = false;
    public bool hasEnvelope = false;
    private bool showingMessage = false;
    private float messageTimer = 0f;

    [Header("Level 3")]
    public int drinkCollected = 0;
    public bool isDrinkGiven = false;
    public int characterGiven = 0;

    [Header("Level 4")]
    public bool isItemSeen = false;

    [Header("Level 5")]
    public int probeItemCollected = 0;
    public bool isItemGiven = false;
    public int characterGiven2 = 0;
    public string heldItem;

    [Header("Level 6")]
    public int maxHealth = 5;
    public bool isGameWon = false;

    [Header("Level 7")]
    public bool hasEscape = false;


    [Header("Level 8")]
    public int platesActive;

    [Header("Level 10")]
    public bool isDia1Done = false;
    public bool isDia2Done = false;
    public static GameManager Instance;
    void Awake()
    {
        Instance = this;
    }
    [Header("Level 9")]
    

    public int Level9DoorID;// Identifies which door
    public bool isLevel9CorrectDoor; //referEnced to level 9, identifies correct door




    void Update()
    {
        switch (levelAt)
        {
            case 1:
                break;

            case 2:
                if (!showingMessage && txtQuestionUpdate.text == "")
                {
                    if (itemsCollected < 3)
                    {
                        int remaining = 3 - itemsCollected;
                        txtQuestionUpdate.text = $"Collect {remaining} more item{(remaining > 1 ? "s" : "")}: {itemsCollected}/3";

                        if (!hasPaper)
                        {
                            txtQuestionUpdate.text += "\nHINT: Find a paper";
                        }
                        if (!hasPencil)
                        {
                            txtQuestionUpdate.text += "\nHINT: Find a pencil";
                        }
                        if (!hasEnvelope)
                        {
                            txtQuestionUpdate.text += "\nHINT: Find an envelope";
                        }
                    }
                    else
                    {
                        txtQuestionUpdate.text = "Look for the door";
                    }
                }

                if (showingMessage)
                {
                    messageTimer -= Time.deltaTime;
                    if (messageTimer <= 0)
                    {
                        showingMessage = false;
                        txtQuestionUpdate.text = "";
                    }
                }
                break;

            case 3:

                break;

            case 4:
                if (isItemSeen)
                {
                    if (txtQuestionUpdate != null)
                        txtQuestionUpdate.text = "Look for the door";
                    else
                        Debug.LogWarning("txtQuestionUpdate is not assigned in the Inspector");
                }
                break;
            case 5:
                if (characterGiven2 == 2)
                {
                    if (txtQuestionUpdate != null)
                        txtQuestionUpdate.text = "Look for the door";
                    else
                        Debug.LogWarning("txtQuestionUpdate is not assigned in the Inspector");
                }
                break;
            case 6:
                if (maxHealth == 0)
                {
                    if (txtInteractMsg != null)
                        txtInteractMsg.text = "Everything's ruined!";
                    Invoke("LoadLevel6", 2f);
                }
                break;
            case 7:
                if (txtInteractMsg != null)
                    txtInteractMsg.text = "I need to pass the library to get to the rooftop.";

                break;
            case 8:
                if(platesActive == 2)
                {
                    txtQuestionUpdate.text = "Go to the door";
                }
                break;
            case 9:
                if (txtQuestionUpdate != null && txtQuestionUpdate.text == "")
                {
                    txtQuestionUpdate.text = "Listen and pick the right door.";
                }
                break;
        }
    }

    public void ShowTemporaryMessage(string message, float duration = 2f)
    {
        txtQuestionUpdate.text = message;
        showingMessage = true;
        messageTimer = duration;
    }

    public void ItemCollected(string itemName)
    {
        itemsCollected++;
        ShowTemporaryMessage($"You collected: {itemName}");
    }

    void LoadLevel6()
    {
        SceneManager.LoadScene("Level_6");
    }

}


