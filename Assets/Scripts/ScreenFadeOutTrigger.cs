using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFadeOutTrigger : MonoBehaviour
{
    public Animator fadeOutAnimator;
    public string animationName;
    public float fadoutDuration = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fadeOutAnimator.speed = 1 / fadoutDuration;
            fadeOutAnimator.Play(animationName);
        }
    }
}
