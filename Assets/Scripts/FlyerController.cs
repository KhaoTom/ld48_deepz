using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyerController : MonoBehaviour
{
    public PathController mainPath;
    public PathController exitScenePath;
    public PathFollower pathFollower;

    public float timeBeforeExitScene = 6;

    public void DoInteraction()
    {
        Invoke("ExitScene", timeBeforeExitScene);
    }

    private void ExitScene()
    {
        pathFollower.SetPath(exitScenePath);
    }
}
