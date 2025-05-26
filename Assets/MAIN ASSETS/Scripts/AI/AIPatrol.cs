using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
    public GameManager gameManager;
    public NavMeshAgent navMeshAgent;

    public Transform Player;

    public bool isAIActive = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
    }

    void Update()
    {
        if (isAIActive)
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }

        else
        {
            navMeshAgent.SetDestination(Player.transform.position);
        }
    }

    void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
    
    {
            isAIActive = true;
        }
    }

    void OnTriggerExit(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
    
    {
            isAIActive = false;
        }
    }

    void OnCollisionEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
        }
    }

    void ReloadScene()
    {
        //SceneManager.LoadScene("lvl" + gameManager.levelAt);
    }

}