using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using DG.Tweening;
using Unity.VisualScripting;

public class MovementController : MonoBehaviour
{
    //movement
    private CharacterController characterController;
    [SerializeField] private float speed;

    //sprint
    private float walkSpeed;
    [SerializeField]private float runSpeed;
    private Camera cam;
    private bool isRunning;

    [SerializeField] private Volume volume;
    private ChromaticAberration chromaticAberration;

    //gravity
    private float gravity = -9.8f;
    private Vector3 velocity;

    [SerializeField] private Transform groundPosition;
    [SerializeField] private bool isGrounded = true;
    private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;

    //footstep
    [SerializeField] private List<AudioClip> walkFootSteps = new List<AudioClip>();
    [SerializeField] private List<AudioClip> runFootSteps = new List<AudioClip>();
    private AudioSource audioSource;
    private float footStepTimer;

    void Start()
    {
        walkSpeed = speed;
        cam = Camera.main;
        volume.profile.TryGet(out chromaticAberration);

        characterController = GetComponent<CharacterController>();

        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        DoMove();
        Gravity();
        DoSprint();
    }

    private void DoMove()
    {
        if (!isGrounded) return;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(direction * speed * Time.deltaTime);

        if(direction != Vector3.zero)
        {
            DoFootSteps();
        }
    }

    private void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundPosition.position, groundDistance, groundMask);
        velocity.y += gravity * Time.deltaTime;

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        characterController.Move(velocity * Time.deltaTime);
    }

    private void DoSprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DOTween.To(() => speed, x => speed = x, runSpeed, 3);
            DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 1, 3);
            cam.DOFieldOfView(90, 3);
            isRunning = true;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            DOTween.To(() => speed, x => speed = x, walkSpeed, 3);
            DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 0, 3);
            cam.DOFieldOfView(60, 3);
            isRunning= false;
        }
    }

    private void DoFootSteps()
    {
        footStepTimer -= Time.deltaTime;

        if(footStepTimer <= 0)
        {
            if (!isRunning)
            {
                audioSource.PlayOneShot(walkFootSteps[Random.Range(0, walkFootSteps.Count)]);
                footStepTimer = 1;
            }
            else
            {
                audioSource.PlayOneShot(runFootSteps[Random.Range(0, runFootSteps.Count)]);
                footStepTimer = 0.4f;
            }
        }
    }

}
