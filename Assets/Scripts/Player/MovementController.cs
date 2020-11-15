using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
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
        CallbackHandler.instance.dashToLocation += DashToLocation;

        if (!es)
        {
            es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        }
    }
    private void OnDestroy()
    {
        CallbackHandler.instance.stopPlayer -= StopPlayer;
        CallbackHandler.instance.dashToLocation -= DashToLocation;
    }
    #endregion Setup & Callbacks

    public EventSystem es;
    float dashTimer;
    bool dashing;
    public float dashSpeed;

    private void Update()
    {
        if (!PlayerStats.instance.init)
            return;

        agent.speed = dashing ? dashSpeed : speed;
        dashing = dashTimer > 0;
        agent.obstacleAvoidanceType = dashing ? ObstacleAvoidanceType.NoObstacleAvoidance : ObstacleAvoidanceType.HighQualityObstacleAvoidance;
        if (dashing)
        {
            dashTimer -= Time.deltaTime;
            dashing = (agent.remainingDistance > 0.5f);
            if (!dashing)
                dashTimer = 0.0f;

            return;
        }

        if (Input.GetMouseButton(0) && !es.IsPointerOverGameObject())
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100.0f, ~LayerMask.GetMask("Environment")))
            {
                agent.destination = hit.point;
            }
        }

        animator.SetFloat("Movement", agent.velocity.magnitude / agent.speed);

        agent.speed = Mathf.Lerp(agent.speed, speed, Time.deltaTime * 4);
    }

    public void StopPlayer()
    {
        if (!dashing)
        {
            agent.ResetPath();
            agent.speed = 0;
        }
    }

    public void DashToLocation(Vector3 _dir)
    {
        dashing = true;
        dashTimer = 1.0f;
        // animator.SetTrigger("Roll");
        agent.destination = _dir;
    }
}
