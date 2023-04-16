using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isDrawed;
    [SerializeField] private Light pointLight;
    [SerializeField] private GameObject candle;
    [SerializeField] private GameObject halo;
    [SerializeField] private GameObject smoke;

    void Start()
    {
        animator = GetComponent<Animator>();
        isDrawed = false;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isDrawed == false)
        {
            isDrawed=true;
            animator.SetBool("isDrawed", true);
            pointLight.enabled = true;
            candle.SetActive(true);
            halo.SetActive(true);
            smoke.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && isDrawed == true)
        {
            isDrawed = false;
            animator.SetBool("isDrawed", false);
            pointLight.enabled = false;
            candle.SetActive(false);
            halo.SetActive(false);
            smoke.SetActive(false);
        }
        
    }
}
