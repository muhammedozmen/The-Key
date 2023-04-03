using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabAI : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] jumpScareSounds;

    [SerializeField] private GameObject targetPosition1;
    [SerializeField] private GameObject targetPosition2;

    private int targetNumber;

    private bool isMoving;

    private void Awake()
    {
        targetNumber = Random.Range(1, 3);
        targetPosition1 = GameObject.FindGameObjectWithTag("TargetPosition1");
        targetPosition2 = GameObject.FindGameObjectWithTag("TargetPosition2");
    }

    void Start()
    {
        isMoving = false;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (isMoving == false)
        {
            audioSource.clip = jumpScareSounds[Random.Range(0, jumpScareSounds.Length)];
            audioSource.Play();
            if (targetNumber == 1)
            {
                agent.destination = targetPosition1.transform.position;
                animator.SetBool("isWalking", true);
            }
            else if (targetNumber == 2)
            {
                agent.destination = targetPosition2.transform.position;
                animator.SetBool("isWalking", true);
            }
            isMoving = true;
        }

        if (isMoving)
        {
            StartCoroutine(AgentDestroy());
        }
    }

    IEnumerator AgentDestroy()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
