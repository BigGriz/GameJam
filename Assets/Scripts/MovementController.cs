using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    #region Setup & Callbacks
    NavMeshAgent agent;
    Animator animator;
    float speed;
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        speed = agent.speed;
    }
    private void Start()
    {
        CallbackHandler.instance.stopPlayer += StopPlayer;
    }
    private void OnDestroy()
    {
        CallbackHandler.instance.stopPlayer -= StopPlayer;
    }
    #endregion Setup & Callbacks

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100.0f))
            {
                agent.destination = hit.point;
            }
        }

        animator.SetFloat("Movement", agent.velocity.magnitude / agent.speed);

        agent.speed = Mathf.Lerp(agent.speed, speed, Time.deltaTime * 4);
    }

    public void StopPlayer()
    {
        agent.ResetPath();
        agent.speed = 0;
    }
}
