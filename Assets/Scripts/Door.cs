using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Door : InteractiveObject
{

    private Animator animator;

    private bool isOpen = false;

    private int shouldOpenAnimParamater = Animator.StringToHash("shouldOpen");

    /// <summary>
    /// Using a constructor to initialize the Display Text in the editor.
    /// </summary>
    /// 
    public Door()
    {
        displayText = nameof(Door);
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

        base.InteractWith();

        animator.SetBool(shouldOpenAnimParamater, true);
        displayText = string.Empty;
        isOpen = true;
        }

    }

}
