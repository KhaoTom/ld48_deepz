using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ScreenFadeOutTrigger : MonoBehaviour
{
    public Animator fadeOutAnimator;

    public AudioMixer mixer;
    public AudioMixerSnapshot[] audioSnapshotsToFadeTo;
    public float[] snapshotWeights;

    public string animationName;
    public float fadoutDuration = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fadeOutAnimator.speed = 1 / fadoutDuration;
            fadeOutAnimator.Play(animationName);


            mixer.TransitionToSnapshots(audioSnapshotsToFadeTo, snapshotWeights, fadoutDuration);
        }
    }
}
