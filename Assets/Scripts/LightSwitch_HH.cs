using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class LightSwitch_HH : InteractiveObject
{
    private Animator animator;


    [SerializeField]
    private bool isTurnedOn = true;

    private int shouldTurnOnAnimParamater = Animator.StringToHash("shouldTurnOn");
    private int shouldTurnOffAnimParamater = Animator.StringToHash("shouldTurnOff");

    [SerializeField]
    private AudioClip turnOnSound;
    [SerializeField]
    private AudioClip turnOffSound;

    [SerializeField]
    private GameObject[] connectedLights;


    /// <summary>
    /// Using a constructor to initialize the Display Text in the editor.
    /// </summary>
    /// 
    public LightSwitch_HH()
    {
        displayText = "Turn on lights";
    }

    private void Update()
    {
        if (!isTurnedOn)
        {
            displayText = "Turn on lights";
            foreach (GameObject light in connectedLights)
            {
                light.SetActive(false);
            }
        }
        if (isTurnedOn)
        {
            displayText = "Turn off lights";
            foreach (GameObject light in connectedLights)
            {
                light.SetActive(true);
            }
        }
    }

    protected override void Awake()
    {
        base.Awake();
        animator = GetComponent<Animator>();
    }

    public override void InteractWith()
    {
        if (!isTurnedOn)
        {
            audioSource.clip = turnOnSound;
            base.InteractWith();

            animator.SetBool(shouldTurnOnAnimParamater, true);
            animator.SetBool(shouldTurnOffAnimParamater, false);
            //displayText = string.Empty;
            isTurnedOn = true;
        }

        else if (isTurnedOn)
        {
            audioSource.clip = turnOffSound;
            base.InteractWith();
            animator.SetBool(shouldTurnOnAnimParamater, false);
            animator.SetBool(shouldTurnOffAnimParamater, true);
            //displayText = string.Empty;
            isTurnedOn = false;
        }

    }
}
