using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls that IInteractive's InteractWith()
/// </summary>


public class InteractWithLookedAt : MonoBehaviour
{

    [SerializeField]
    private DetectLookedAtInteractive detectLookedAtInteractive;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Interact") && detectLookedAtInteractive.lookedAtInteractive != null)
        {

            //Debug.Log("Player Pressed Interact Button");
            detectLookedAtInteractive.lookedAtInteractive.InteractWith();

        }
        
    }
}
