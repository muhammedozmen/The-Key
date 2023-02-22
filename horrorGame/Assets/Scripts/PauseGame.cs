using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject resume;
    [SerializeField] private GameObject quit;
    [SerializeField] private GameObject cross;
    [SerializeField] private GameObject cam;

    private bool on;
    private bool off;
    
    void Start()
    {
        // Lock the mouse cursor to the game screen.
        Cursor.lockState = CursorLockMode.Locked;


        menu.SetActive(false);
        resume.SetActive(false);
        quit.SetActive(false);
        cross.SetActive(true);
        off = true;
        on = false;       
    }

    
    void Update()
    {
         if(off && Input.GetKeyDown(KeyCode.Escape))
         {
             Cursor.visible = true;
             Cursor.lockState = CursorLockMode.None;
             Time.timeScale = 0;
             cam.GetComponent<FirstPersonLook>().enabled = false;
             menu.SetActive(true);
             cross.SetActive(false);
             resume.SetActive(true);
             quit.SetActive(true);
             off = false;
             on = true;
         }
         else if(on && Input.GetKeyDown(KeyCode.Escape))
         {
             Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
             Time.timeScale = 1;
             cam.GetComponent<FirstPersonLook>().enabled = true;
             menu.SetActive(false);
             cross.SetActive(true);
             resume.SetActive(false);
             quit.SetActive(false);
             off = true;
             on = false;
         }
        
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        cam.GetComponent<FirstPersonLook>().enabled = true;
        menu.SetActive(false);
        cross.SetActive(true);
        resume.SetActive(false);
        quit.SetActive(false);
        off = true;
        on = false;

    }

    public void Exit()
    {
        Application.Quit();
    }
}
