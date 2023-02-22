using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DevilAI : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent agent;

    [SerializeField] private GameObject target;
    [SerializeField] private SkinnedMeshRenderer dress;
    [SerializeField] private SkinnedMeshRenderer eyes;
    [SerializeField] private SkinnedMeshRenderer plane;
    [SerializeField] private SkinnedMeshRenderer body;

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
        rageLevel = 1;
        dress.enabled = false;
        eyes.enabled = false;
        plane.enabled = false;
        body.enabled = false;
    }

    
    void Update()
    {
        
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
            isRunning = false;
            animator.SetBool("isWalking", true);
            isMoving = true;
            if(agent.remainingDistance < agent.stoppingDistance)
            {
                dress.enabled = true;
                eyes.enabled = true;
                plane.enabled = true;
                body.enabled = true;
                isMoving = false;
                animator.SetBool("isWalking", false);
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
            isRunning = true;
            agent.destination = target.transform.position;
            animator.SetBool("isRunning", true);
            isMoving = true;
            if (agent.remainingDistance < agent.stoppingDistance)
            {
                dress.enabled = true;
                eyes.enabled = true;
                plane.enabled = true;
                body.enabled = true;
                isMoving = false;
                animator.SetBool("isRunning", false);
            }
            if(isMoving)
            {
                //DoFootSteps();
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
