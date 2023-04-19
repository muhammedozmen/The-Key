using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroSceneManager : MonoBehaviour
{
    [SerializeField] private FadeUI FadeUI;
    [SerializeField] private ASyncLoader ASyncLoader;

    [SerializeField] private string levelToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            FadeUI.Fader();
            ASyncLoader.LoadLevel(levelToLoad);
        }
    }
}
