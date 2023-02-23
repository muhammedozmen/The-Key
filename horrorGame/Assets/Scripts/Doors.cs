using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public Animator animator;
    public GameObject openText;

    public AudioSource AudioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;

     public int number1;
     public int number2;
     public int number3;
     public int number4;

    [SerializeField] private InteractCodeBlock CodeBlock1;
    [SerializeField] private InteractCodeBlock CodeBlock2;
    [SerializeField] private InteractCodeBlock CodeBlock3;
    [SerializeField] private InteractCodeBlock CodeBlock4;

    private bool isOpened;

    
    void Awake()
    {
        isOpened = false;
        number1 = Random.Range(0, 10);
        number2 = Random.Range(0, 10);
        number3 = Random.Range(0, 10);
        number4 = Random.Range(0, 10);
    }

    
    void Update()
    {  if(isOpened == false)
        {
            if (number1 == CodeBlock1.secretCode && number2 == CodeBlock2.secretCode && number3 == CodeBlock3.secretCode && number4 == CodeBlock4.secretCode)
            {
                isOpened = true;
                DoorOpens();
            }
        }
       else if(isOpened == true)
        {
            if (number1 != CodeBlock1.secretCode || number2 != CodeBlock2.secretCode || number3 != CodeBlock3.secretCode || number4 != CodeBlock4.secretCode)
            {
                isOpened = false;
                DoorCloses();
            }
        }
    
        
        
    }

    private void DoorOpens()
    {
        animator.SetBool("isDoorOpen", true);
        AudioSource.PlayOneShot(doorOpenSound);
    }

    private void DoorCloses()
    {
        animator.SetBool("isDoorOpen", false);
        AudioSource.PlayOneShot(doorCloseSound);
    }


}
