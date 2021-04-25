using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerController : MonoBehaviour
{
    public PathController mainPath;
    public PathController exitScenePath;
    public PathFollower pathFollower;
    public AudioSource interactSound;

    public float timeBeforeExitScene = 6;

    public void DoInteraction()
    {
        Invoke("ExitScene", timeBeforeExitScene);
        interactSound.Play();
    }

    private void ExitScene()
    {
        pathFollower.SetPath(exitScenePath);
    }
}
