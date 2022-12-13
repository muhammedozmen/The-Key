using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensivity = 100f;
    public Transform body;

    private float xRotation = 0;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float vertical = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation -= vertical;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        body.Rotate(Vector3.up * horizontal);
    }

    
}
