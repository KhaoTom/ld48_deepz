using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMaterialOffset : MonoBehaviour
{
    public Renderer target;
    public Vector2 scrollspeed;
    
    private void Update()
    {
        target.material.mainTextureOffset = new Vector2(
            target.material.mainTextureOffset.x + scrollspeed.x * Time.deltaTime,
            target.material.mainTextureOffset.y + scrollspeed.y * Time.deltaTime
            );
    }
}
