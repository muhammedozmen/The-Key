using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isDrawed;
    [SerializeField] private GameObject pointLight;

    
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
            pointLight.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.F) && isDrawed == true)
        {
            isDrawed = false;
            animator.SetBool("isDrawed", false);
            pointLight.SetActive(false);
        }
        
    }
}
