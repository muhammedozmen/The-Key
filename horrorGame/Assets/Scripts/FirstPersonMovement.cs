using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering;
using DG.Tweening;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    [Header("Running")]
    public bool canRun;
    public bool IsRunning { get; private set; }
    [SerializeField] private float runSpeed;
    [SerializeField] private KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rb;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    //footstep
    [SerializeField] private List<AudioClip> walkFootSteps = new List<AudioClip>();
    [SerializeField] private List<AudioClip> runFootSteps = new List<AudioClip>();
    private AudioSource audioSource;
    private float footStepTimer;
    [SerializeField] private float walkFootStepTimer;
    [SerializeField] private float runFootStepTimer;


    private bool isRunning;

    [SerializeField] private Volume volume;
    private ChromaticAberration chromaticAberration;

    private Camera cam;


    void Awake()
    {
        // Get the rigidbody on this.
        rb = GetComponent<Rigidbody>();

        audioSource = GetComponent<AudioSource>();

        volume.profile.TryGet(out chromaticAberration);

        cam = Camera.main;

        canRun = true;

        
    }

    private void Start()
    {
        DOTween.SetTweensCapacity(500, 50);
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);


        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rb.velocity = transform.rotation * new Vector3(targetVelocity.x, rb.velocity.y, targetVelocity.y);

        if (IsRunning)
        {
            isRunning = true;
            if (targetVelocity != Vector2.zero)
            {
                DoFootSteps();
                DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 1, 3);
                cam.DOFieldOfView(70, 1);
            }
        }
        else if (IsRunning == false)
        {
            isRunning = false;
            if (targetVelocity != Vector2.zero)
            {
                DoFootSteps();
                DOTween.To(() => chromaticAberration.intensity.value, x => chromaticAberration.intensity.value = x, 0, 3);
                cam.DOFieldOfView(60, 1);
            }
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