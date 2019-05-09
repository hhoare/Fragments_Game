using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : InteractiveObject
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


    private new Renderer renderer;
    private new Collider collider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
    }
    // public override string DisplayText => isLocked ? lockedDisplayText : base.DisplayText;


    public override string DisplayText
    {
        get
        {
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
    public WoodenPlank()
    {
        displayText = "Open " + nameof(WoodenPlank);
    }

    private void Update()
    {
        if (!hasKey)
        {
            displayText = "A " + nameof(WoodenPlank);
        }
        if (isOpen)
        {
            displayText = "Saw off the " + nameof(WoodenPlank);
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


            if (isLocked && !hasKey)   //locked no key
            {
                audioSource.clip = lockedSound;
            }
            else if (isLocked && hasKey)    //locked has key
            {
                audioSource.clip = openSound;
                UnlockDoor();
            }

            base.InteractWith();    //plays a sound effect
        

    }

    private void UnlockDoor()
    {
        isLocked = false;
        if (key != null && consumesKey)
        {
            PlayerInventory.InventoryObjects.Remove(key);   
        }
        renderer.enabled = false;
        collider.enabled = false;
    }
}
