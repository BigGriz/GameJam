using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMenuWalker : MonoBehaviour
{
    public GameObject startWaypoint;
    public GameObject endWaypoint;
    GameObject currentWaypoint;

    NavMeshAgent agent;
    Animator animator;

    public float waitTimer = 900.0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentWaypoint = startWaypoint;
        agent.SetDestination(currentWaypoint.transform.position);
    }

    private void Update()
    {
        animator.SetFloat("Movement", agent.velocity.magnitude / agent.speed);

        waitTimer -= Time.deltaTime;

        // Turn Around
        if (waitTimer <= 0)
        {

            currentWaypoint = (currentWaypoint == endWaypoint) ? startWaypoint : endWaypoint;
            Vector3 dest = currentWaypoint.transform.position;
            agent.SetDestination(dest);
            waitTimer = 900.0f;
        }
        // Reached Destination
        if (agent.remainingDistance <= agent.stoppingDistance + 0.1f && waitTimer > 3.0f)
        {
            waitTimer = 3.0f;
        }
    }

}
