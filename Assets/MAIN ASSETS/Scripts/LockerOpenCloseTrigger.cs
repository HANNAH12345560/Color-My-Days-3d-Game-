using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LockerOpenCloseTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;
    public GameObject DoorLocker;

    private bool isOpen = false;
    private bool isAnimating = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;
    public float animationDuration = 0.5f;

    void Start()
    {
        if (DoorLocker != null)
        {
            closedRotation = DoorLocker.transform.rotation;
            openRotation = closedRotation * Quaternion.Euler(0, -180, 0);
        }
    }

    void OnTriggerEnter(Collider actor)
    {
        if (actor.CompareTag("Player") && txtInteractMsg != null)
        {
            txtInteractMsg.text = isOpen ? "Press [E] to close" : "Press [E] to open";
        }
    }

    void OnTriggerStay(Collider actor)
    {
        if (actor.CompareTag("Player") && !isAnimating && txtInteractMsg != null)
        {
            if (Input.GetKeyDown(KeyCode.E) && DoorLocker != null)
            {
                if (!isOpen)
                {
                    StartCoroutine(RotateDoor(DoorLocker.transform, closedRotation, openRotation));
                    isOpen = true;
                    string itemTag = gameObject.tag;
                    if (itemTag == "Locker3")
                    {
                        txtInteractMsg.text = "This one is empty.";
                    }
                    else
                    {
                        txtInteractMsg.text = "Press [E] to close";
                    }
                }
                else
                {
                    StartCoroutine(RotateDoor(DoorLocker.transform, openRotation, closedRotation));
                    isOpen = false;
                    txtInteractMsg.text = "Press [E] to open";
                }
            }
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.CompareTag("Player") && txtInteractMsg != null)
        {
            txtInteractMsg.text = "";
        }
    }

    IEnumerator RotateDoor(Transform door, Quaternion from, Quaternion to)
    {
        isAnimating = true;
        float elapsed = 0f;
        while (elapsed < animationDuration)
        {
            door.rotation = Quaternion.Slerp(from, to, elapsed / animationDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        door.rotation = to;
        isAnimating = false;
    }
}
