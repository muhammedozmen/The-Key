using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevilAI : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent agent;

    public GameObject target;
    [SerializeField] private GameObject targetPlayer;
    [SerializeField] private SkinnedMeshRenderer dress;
    [SerializeField] private SkinnedMeshRenderer eyes;
    [SerializeField] private SkinnedMeshRenderer plane;
    [SerializeField] private SkinnedMeshRenderer body;

    [SerializeField] private float visibleDistance;
    private float distance;
    [SerializeField] private float runningSpeed;

    public int rageLevel;
    public float triggerDistance;

    private AudioSource audioSource;
    [SerializeField] private bool isMoving;
    public bool isTargetable;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        rageLevel = 1;
        dress.enabled = false;
        eyes.enabled = false;
        plane.enabled = false;
        body.enabled = false;
    }

    
    void Update()
    {
        if (isMoving == false && isTargetable)
        {
            target = targetPlayer;
        }
        
        //devil ile hedef aras?ndaki mesafe
        distance = Vector3.Distance(transform.position, target.transform.position);

        //devil, rage seviyesi 5 veya 5'ten kücükse yürüyerek ilerlesin
        if(distance < triggerDistance && rageLevel <= 5)
        {
            agent.enabled = true;
            dress.enabled = false;
            eyes.enabled = false;
            plane.enabled = false;
            body.enabled = false;
            agent.destination = target.transform.position;
            animator.SetBool("isWalking", true);
            isMoving = true;
            if(agent.remainingDistance < visibleDistance)
            {
                dress.enabled = true;
                eyes.enabled = true;
                plane.enabled = true;
                body.enabled = true;
                if(agent.remainingDistance < agent.stoppingDistance)
                {
                    isMoving = false;
                    animator.SetBool("isWalking", false);
                }    
            }
            if (isMoving)
            {
                //DoFootSteps();
            }
        }

        //rage seviyesi 5'ten büyükse kosarak ilerlesin
        else if(distance < triggerDistance && rageLevel < 11 && rageLevel > 5)
        {
            agent.enabled = true;
            dress.enabled = false;
            eyes.enabled = false;
            plane.enabled = false;
            body.enabled = false;
            agent.speed = runningSpeed;
            agent.destination = target.transform.position;
            animator.SetBool("isRunning", true);
            isMoving = true;
            if (agent.remainingDistance < visibleDistance)
            {
                dress.enabled = true;
                eyes.enabled = true;
                plane.enabled = true;
                body.enabled = true;
                if (agent.remainingDistance < agent.stoppingDistance)
                {
                    isMoving = false;
                    animator.SetBool("isRunning", false);
                }
            }
        }

        //eger görüs acisinin disinda ise devil dursun
        else
        {
            agent.enabled = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }

}
