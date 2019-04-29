using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Door : InteractiveObject
{
    [Tooltip("Assigning a Key here will lock the door.")]
    [SerializeField]
    private InventoryObject key;

    [Tooltip("If this is checked, assigned key will be removed from inventory once used")]
    [SerializeField]
    private bool consumesKey;

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

    private bool hasKey => PlayerInventory.InventoryObjects.Contains(key);
    private Animator animator;
    private bool isOpen = false;
    private int shouldOpenAnimParamater = Animator.StringToHash("shouldOpen");
    private int shouldCloseAnimParamater = Animator.StringToHash("shouldClose");
    private int shouldLockedAnimParamater = Animator.StringToHash("shouldLocked");



   // public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;


   public override string DisplayText {
        get {
            string toReturn;
            if (isLocked)
            {
                toReturn = hasKey ? $"Use {key.ObjectName}" : lockedDisplayText;
            }
            else
            {
                toReturn = base.DisplayText;
            }
            return toReturn;
        }
    }
    

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
        InitializeIsLocked();
    }

    private void InitializeIsLocked()
    {
        if (key != null)
            isLocked = true;
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            if (!isLocked)  //not locked
            {
                audioSource.clip = openSound;
                animator.SetBool(shouldOpenAnimParamater, true);
                animator.SetBool(shouldCloseAnimParamater, false);
                isOpen = true;
            }
            else if (isLocked && !hasKey)   //locked no key
            {
                audioSource.clip = lockedSound;
                animator.Play("Door_Locked_Try");
            }
            else if (isLocked && hasKey)    //locked has key
            {
                audioSource.clip = openSound;
                animator.SetBool(shouldOpenAnimParamater, true);
                animator.SetBool(shouldCloseAnimParamater, false);
                isOpen = true;
                UnlockDoor();
            }
            base.InteractWith();    //plays a sound effect
        }
        else if (isOpen)
        {
            audioSource.clip = closeSound;
            base.InteractWith(); //plays a sound effect
            animator.SetBool(shouldOpenAnimParamater, false);
            animator.SetBool(shouldCloseAnimParamater, true);
            isOpen = false;
        }

    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key);
        }
    }
}
