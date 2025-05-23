using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Lvl6Obstacle : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    public HealthBar healthBar; // Reference to your HealthBar script
    public int startingHealth = 5; // Set this to your initial health
    public Image HpIndicator;

    void OnTriggerEnter(Collider actor)
    {
        HpIndicator = HpIndicator.GetComponent<Image>();
        switch (gameManager.maxHealth)
        {
            case 1:
              HpIndicator.color = new Color(HpIndicator.color.r,HpIndicator.color.g,HpIndicator.color.b,0.25f); // 
                break;
            case 2:
                HpIndicator.color = new Color(HpIndicator.color.r, HpIndicator.color.g, HpIndicator.color.b, 0.5f); // 
                break;
            case 3:
                HpIndicator.color = new Color(HpIndicator.color.r, HpIndicator.color.g, HpIndicator.color.b, 0.75f); // 
                break;
            case 4:
                HpIndicator.color = new Color(HpIndicator.color.r, HpIndicator.color.g, HpIndicator.color.b, 0.1f); // 
                break;
        }
        if (actor.CompareTag("Player"))
        {
            if (gameObject.tag == "Mud")
            {
                gameManager.maxHealth -= 1;
                txtInteractMsg.text = "Why did it have to be mud?!";
            }
            else if (gameObject.tag == "Puddle")
            {
                gameManager.maxHealth -= 1;
                txtInteractMsg.text = "Now I’m soaked!";
            }
            else if (gameObject.tag == "Gate")
            {
                gameManager.maxHealth -= 1;
                txtInteractMsg.text = "Ouch!";
            }

            // Clamp to avoid negative health
            if (gameManager.maxHealth < 0)
                gameManager.maxHealth = 0;

            // Update the health bar
            if (healthBar != null)
            {
                float fraction = Mathf.Clamp01((float)gameManager.maxHealth / startingHealth);
                healthBar.UpdateHealth(fraction);
            }
        }
    }


   
}
