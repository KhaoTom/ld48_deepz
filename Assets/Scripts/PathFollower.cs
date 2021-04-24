using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public GameObject pathParent;
    public float moveSpeed = 3;
    public float rotationSpeed = 180;
    public Transform[] nodes;
    public int currentTargetId = -1;

    private void Start()
    {
        // find all nodes in the path
        var nodeswithPaenrtUnityDum = new List<Transform>(pathParent.GetComponentsInChildren<Transform>());
        nodeswithPaenrtUnityDum.RemoveAt(0);
        nodes = nodeswithPaenrtUnityDum.ToArray();

        if (nodes == null || nodes.Length == 0)
        {
            Debug.LogError("We got no path nodes, yo.", this);
            this.enabled = false;
        }

        // find the closest node to use as the first node
        currentTargetId = GetClosestPosition(nodes, transform.position);
    }

    private int GetClosestPosition(Transform[] transforms, Vector3 from)
    {
        int closest = -1;
        for (int i = 0; i < transforms.Length; ++i)
        {
            if (closest == -1)
            {
                closest = i;
            }
            else if (Vector3.Distance(transforms[closest].position, from) > Vector3.Distance(transforms[i].position, from))
            {
                closest = i;
            }
        }
        return closest;
    }

    private void Update()
    {
        Vector3 target = nodes[currentTargetId].position;

        // move towards current target node
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

        // rotate towards target node
        
        var lookat = Quaternion.LookRotation(target - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookat, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // if other is a path node then get the next node in path and set it as current target
        if (this.enabled && other.CompareTag("PathNode"))
        {
            currentTargetId += 1;
            if (currentTargetId >= nodes.Length)
            {
                currentTargetId = 0;
            }
        }
    }
}
