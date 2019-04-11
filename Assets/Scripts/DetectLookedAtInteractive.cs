using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects interactive elements the player is looking at using a raycast
/// https://docs.unity3d.com/ScriptReference/Physics.Raycast.html
/// </summary>


public class DetectLookedAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect interactive objects")]
    [SerializeField]
    private Transform raycastOrigin;

    [Tooltip("How far from the raycastOrigin we will search for interactive objects")]
    [SerializeField]
    private float maxRange = 2.5f;
    
    /// <summary>
    /// Event raised when player looks at a different IInteractive.
    /// </summary>
    public static event Action<IInteractive> LookedAtInteractiveChanged;

    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
       private set
        {
            bool isInteractiveChanged = value != lookedAtInteractive;
            if (isInteractiveChanged)
            {
                lookedAtInteractive = value;
                LookedAtInteractiveChanged?.Invoke(lookedAtInteractive);   //checks if its null (?.)
            }
            
        }
    }

    private IInteractive lookedAtInteractive;
    
    private void FixedUpdate()
    {

        LookedAtInteractive = GetLookedAtInteractive();

    }

    /// <summary>
    /// Raycasts forward from the camera to look for IInteractive
    /// </summary>
    /// <returns>returning the first IInteractive detected or null if nothing if found</returns>
    private IInteractive GetLookedAtInteractive()
    {
        Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);
        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hitInfo, maxRange);


        IInteractive interactive = null;

        LookedAtInteractive = interactive;

        if (objectWasDetected && hitInfo.collider.gameObject.name != "FPSPLAYER")
        {
            // Debug.Log($"Player is looking at {hitInfo.collider.gameObject.name}");

            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        return interactive;

    }








}
