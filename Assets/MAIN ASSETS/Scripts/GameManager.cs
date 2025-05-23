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
                        txtInteractMsg.text = "Everything’s ruined!";
                    Invoke("LoadLevel6", 2f);
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

