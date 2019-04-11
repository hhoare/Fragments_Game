using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player presses the interact button while looking at an IInteractive,
/// and then calls that IInteractive's InteractWith()
/// </summary>


public class InteractWithLookedAt : MonoBehaviour
{


    private IInteractive lookedAtInteractive;



    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Interact") && lookedAtInteractive != null)
        {

            //Debug.Log("Player Pressed Interact Button");
            lookedAtInteractive.InteractWith();

        }
        
    }

    /// <summary>
    /// Event handler for DetectLookedAtInteractive.LookedAtInteractiveChanged
    /// </summary>
    /// <param name="newLookedAtInteractive">A reference to the new IInteractive the player is looking at.</param>
    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;

    }


    #region event subscription / unsubscription
    private void OnEnable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookedAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion


}
