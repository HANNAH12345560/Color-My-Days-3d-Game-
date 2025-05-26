using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;
using UnityEngine.SceneManagement;

public class AIPatrol : MonoBehaviour
{
    public GameManager gameManager;
    public NavMeshAgent navMeshAgent;
    public Transform Player;
    public TMP_Text txtQuestionUpdate;
    public TMP_Text txtInteractMsg;

    [Header("AI Follow Offset")]
    public Vector3 followOffset; 

    [Header("Patrol Settings")]
    public float patrolSpeed = 0.5f;
    public float followSpeed = 0.5f;
    public float patrolTime = 5f;
    public float patrolRadius = 10f;

    private bool isAIActive = false;
    private bool isPatrolling = true;
    private float patrolTimer = 0f;
    private Vector3 patrolTarget;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false;
        navMeshAgent.speed = patrolSpeed;
        SetNewPatrolDestination();
    }

    void Update()
    {
        if (isPatrolling)
        {
            patrolTimer += Time.deltaTime;
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                SetNewPatrolDestination();
            }
            if (patrolTimer >= patrolTime)
            {
                isPatrolling = false;
                isAIActive = true;
                navMeshAgent.speed = followSpeed;
            }
        }

        if (isAIActive)
        {
            Vector3 targetPosition = Player.transform.position + Player.transform.TransformDirection(followOffset);
            navMeshAgent.SetDestination(targetPosition);
        }
    }

    void SetNewPatrolDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * patrolRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, patrolRadius, NavMesh.AllAreas))
        {
            patrolTarget = hit.position;
            navMeshAgent.SetDestination(patrolTarget);
        }
    }

    void OnTriggerEnter(Collider actor)
    {
        if (actor.gameObject.CompareTag("Player"))
        {
            if (txtInteractMsg != null)
                txtInteractMsg.text = "Hey! What are you doing here?!";

            isAIActive = true;
            isPatrolling = false;
            navMeshAgent.speed = followSpeed;
            Invoke("LoadLevel7", 2f);
        }
    }

    void LoadLevel7()
    {
        SceneManager.LoadScene("Level_7");
    }

    public void DeactivateAI()
    {
        isAIActive = false;
    }
}