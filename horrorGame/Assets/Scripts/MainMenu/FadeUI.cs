using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUI : MonoBehaviour
{
    private int fadeInAmount = 0;
    private int fadeOutAmount = 1;
    [SerializeField] private float fadeInDuration = 2;
    [SerializeField] private float fadeOutDuration = 2;
    [SerializeField] private CanvasGroup myFadingGroup;


    public void Fader()
    {
        myFadingGroup.DOFade(fadeOutAmount, fadeOutDuration);
        StartCoroutine(FadeWaiting());
    }

    IEnumerator FadeWaiting()
    {
        yield return new WaitForSeconds(2);
        myFadingGroup.DOFade(fadeInAmount, fadeInDuration);
    }
}
