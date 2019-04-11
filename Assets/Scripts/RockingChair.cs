using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class RockingChair : InteractiveObject
{
    private Animator animator;

    private bool isRocking = false;

    private int shouldRockAnimParamater = Animator.StringToHash("shouldRock");
    private int shouldStopAnimParamater = Animator.StringToHash("shouldStop");


    /// <summary>
    /// Using a constructor to initialize the Display Text in the editor.
    /// </summary>
    /// 
    public RockingChair()
    {
        displayText = "Rock Chair";
    }

    private void Update()
    {
        if (!isRocking)
        {
            displayText = "Rock Chair";
        }
        if (isRocking)
        {
            displayText = "Stop Chair";
        }
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (!isRocking)
        {
            base.InteractWith();

            animator.SetBool(shouldRockAnimParamater, true);
            animator.SetBool(shouldStopAnimParamater, false);
            //displayText = string.Empty;
            isRocking = true;
        }

        else if (isRocking)
        {
            base.InteractWith();
            animator.SetBool(shouldRockAnimParamater, false);
            animator.SetBool(shouldStopAnimParamater, true);
            //displayText = string.Empty;
            isRocking = false;
        }

    }

}
