using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject hud;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject cam;

    private bool isOn = false;
    
    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;
        cross.SetActive(true);
        menu.SetActive(false);
    }

    
    void Update()
    {
         if(isOn == false && Input.GetKeyDown(KeyCode.Escape))
         {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            cam.GetComponent<FirstPersonLook>().enabled = false;
            cross.SetActive(false);
            menu.SetActive(true);
            hud.SetActive(false);
            isOn = true;
         }       
    }

    public void Resume()
    {
        menu.SetActive(false);
        hud.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        cam.GetComponent<FirstPersonLook>().enabled = true;
        cross.SetActive(true);
        isOn = false;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
