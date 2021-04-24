using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    private void OnDrawGizmosSelected()
    {

        var nodeswithPaenrtUnityDum = new List<Transform>(GetComponentsInChildren<Transform>());
        nodeswithPaenrtUnityDum.RemoveAt(0);

        Transform[] nodes;
        nodes = nodeswithPaenrtUnityDum.ToArray();

        if (nodes == null || nodes.Length == 0)
        {
            Debug.LogError("We got no path nodes, yo.", this);
            
        }
        else if (nodes.Length == 1)
        {
            return;
        }

        for (int i = 0; i < nodes.Length; ++i)
        {
            if (i == nodes.Length -1)
            {
                Gizmos.DrawLine(nodes[i].position, nodes[0].position);
            }
            else
            {
                Gizmos.DrawLine(nodes[i].position, nodes[i+1].position);

            }

        }
    }

}
