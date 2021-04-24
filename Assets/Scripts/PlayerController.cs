using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private MeshRenderer capsuleMeshRenderer;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        capsuleMeshRenderer = GetComponent<MeshRenderer>();
        capsuleMeshRenderer.enabled = false;
    }
    
    private void Update()
    {
        
    }
}
