using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevilAI : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent agent;

    [SerializeField] private GameObject target;

    private float distance;
    [SerializeField] private float runningSpeed;

    public int rageLevel;
    public float triggerDistance;

    private AudioSource audioSource;
    private float footStepTimer;
    private bool isRunning;
    [SerializeField] private bool isMoving;

    [SerializeField] private List<AudioClip> walkFootSteps = new List<AudioClip>();
    [SerializeField] private List<AudioClip> runFootSteps = new List<AudioClip>();

    [SerializeField] private float walkFootStepTimer;
    [SerializeField] private float runFootStepTimer;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        //rageLevel = 1;
    }

    
    void Update()
    {
        
        //devil ile hedef aras?ndaki mesafe
        distance = Vector3.Distance(transform.position, target.transform.position);

        //devil, rage seviyesi 5 veya 5'ten k�c�kse y�r�yerek ilerlesin
        if(distance < triggerDistance && rageLevel <= 5)
        {
            agent.enabled = true;
            agent.destination = target.transform.position;
            isRunning = false;
            animator.SetBool("isWalking", true);
            isMoving = true;
            if(agent.remainingDistance < agent.stoppingDistance)
            {   
                isMoving = false;
                animator.SetBool("isWalking", false);
            }
            if (isMoving)
            {
                DoFootSteps();
            }
        }

        //rage seviyesi 5'ten b�y�kse kosarak ilerlesin
        else if(distance < triggerDistance && rageLevel < 11 && rageLevel > 5)
        {
            agent.enabled = true;
            agent.speed = runningSpeed;
            isRunning = true;
            agent.destination = target.transform.position;
            animator.SetBool("isRunning", true);
            isMoving = true;
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                isMoving = false;
                animator.SetBool("isRunning", false);
            }
            if(isMoving)
            {
                DoFootSteps();
            }
        }

        //eger g�r�s acisinin disinda ise devil dursun
        else
        {
            agent.enabled = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
        }
    }

    private void DoFootSteps()
    {
        footStepTimer -= Time.deltaTime;

        if (footStepTimer <= 0)
        {
            if (isRunning == false)
            {
                audioSource.PlayOneShot(walkFootSteps[Random.Range(0, walkFootSteps.Count)]);
                footStepTimer = walkFootStepTimer;
            }
            else
            {
                audioSource.PlayOneShot(runFootSteps[Random.Range(0, runFootSteps.Count)]);
                footStepTimer = runFootStepTimer;
            }
        }
    }
}
