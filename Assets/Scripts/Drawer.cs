using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Drawer : InteractiveObject
{
    private Animator animator;

    private bool isOpen = false;

    private int shouldOpenAnimParamater = Animator.StringToHash("shouldOpen");
    private int shouldCloseAnimParamater = Animator.StringToHash("shouldClose");

    [SerializeField]
    private string name;

    [SerializeField]
    private AudioClip openSound;
    [SerializeField]
    private AudioClip closeSound;


    /// <summary>
    /// Using a constructor to initialize the Display Text in the editor.
    /// </summary>
    /// 
    public Drawer()
    {
        displayText = "Open " + name;
    }

    private void Update()
    {
        if (!isOpen)
        {
            displayText = "Open " + name;
        }
        if (isOpen)
        {
            displayText = "Close " + name;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (!isOpen)
        {
            audioSource.clip = openSound;
            base.InteractWith();

            animator.SetBool(shouldOpenAnimParamater, true);
            animator.SetBool(shouldCloseAnimParamater, false);
            //displayText = string.Empty;
            isOpen = true;
        }

        else if (isOpen)
        {
            audioSource.clip = closeSound;
            base.InteractWith();
            animator.SetBool(shouldOpenAnimParamater, false);
            animator.SetBool(shouldCloseAnimParamater, true);
            //displayText = string.Empty;
            isOpen = false;
        }

    }

}
