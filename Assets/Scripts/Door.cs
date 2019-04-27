using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Door : InteractiveObject
{

    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;
    [SerializeField]
    private AudioClip lockedSound;

    [Tooltip("Check this box to lock the door.")]
    [SerializeField]
    private bool isLocked;

    [Tooltip("Display text for locked doors.")]
    [SerializeField]
    private string lockedDisplayText = "Locked";
    

    private Animator animator;
    private bool isOpen = false;
    private int shouldOpenAnimParamater = Animator.StringToHash("shouldOpen");
    private int shouldCloseAnimParamater = Animator.StringToHash("shouldClose");
    private int shouldLockedAnimParamater = Animator.StringToHash("shouldLocked");



    public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;


    /*  Same as line above
   public override string DisplayText {
        get {
            if (isLocked)
            {
                return lockedDisplayText;
            }
            else {
                return base.DisplayText;
            }
        }
    }
    */

    /// <summary>
    /// Using a constructor to initialize the Display Text in the editor.
    /// </summary>
    /// 
    public Door()
    {
        displayText = "Open " + nameof(Door);
    }

    private void Update()
    {
        if (!isOpen)
        {
            displayText = "Open " + nameof(Door);
        }
        if (isOpen)
        {
            displayText = "Close " + nameof(Door);
        }
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (!isOpen && !isLocked)
        {
            audioSource.clip = openSound;
            base.InteractWith();    //plays a sound effect

            animator.SetBool(shouldOpenAnimParamater, true);
            animator.SetBool(shouldCloseAnimParamater, false);
            //displayText = string.Empty;
            isOpen = true;
        }
        else if (!isOpen && isLocked) {

            audioSource.clip = lockedSound;
            base.InteractWith();    //plays a sound effect

            animator.Play("Door_Locked_Try");

        }

        else if (isOpen)
        {
            audioSource.clip = closeSound;
            base.InteractWith(); //plays a sound effect
            animator.SetBool(shouldOpenAnimParamater, false);
            animator.SetBool(shouldCloseAnimParamater, true);
            //displayText = string.Empty;
            isOpen = false;
        }

    }

}
