using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isDrawed;
    [SerializeField] private GameObject pointLight;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isDrawed = false;
    }

    // Update is called once per frame
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
