using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    [Header("Levels To Load")]
    [SerializeField] private string newGameLevel;

    private void OnEnable()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
