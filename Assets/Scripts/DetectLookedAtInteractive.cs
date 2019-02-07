using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects interactive elements the player is looking at using a raycast
/// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
/// </summary>


public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactable objects")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycastOrigin we will search for interactable objects")]
    [SerializeField]
    private float maxRange = 2.5f;
    


    private void FixedUpdate()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);

        if (objectWasDetected) {
            Debug.Log($"Player is looking at {hitInfo.collider.gameObject.name}");
        }

    }


}
