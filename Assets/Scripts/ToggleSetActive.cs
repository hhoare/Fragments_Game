using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : InteractiveObject
{
    [Tooltip("The object that will be toggled on/off")]
    [SerializeField]
    private GameObject objectToToggle;

    [Tooltip("Can the player interact with this toggle more than once?")]
    [SerializeField]
    private bool isReusable = true;

    private bool hasBeenUsed = false;

    /// <summary>
    /// Toggles the activeSelf value for the objectToToggle when the player interacts with this object.
    /// </summary>
    public override void InteractWith()
    {
        if (isReusable || !hasBeenUsed)
        {
            base.InteractWith();
            objectToToggle.SetActive(!objectToToggle.activeSelf); //inverses the current active value (on or off)
            hasBeenUsed = true;
            if (!isReusable) displayText = string.Empty;
        }

    }


}
