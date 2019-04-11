using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lamp_HH : InteractiveObject
{

    [SerializeField]
    private GameObject light;

    [SerializeField]
    private bool isOn = false;

    [SerializeField]
    private AudioClip onSound;
    [SerializeField]
    private AudioClip offSound;


    /// <summary>
    /// Using a constructor to initialize the Display Text in the editor.
    /// </summary>
    /// 
    public Lamp_HH()
    {
        displayText = "Turn on lamp";
    }

    private void Update()
    {
        if (!isOn)
        {
            displayText = "Turn on lamp";
            light.SetActive(false);
        }
        if (isOn)
        {
            displayText = "Turn off lamp";
            light.SetActive(true);
        }
    }

    protected override void Awake()
    {
        base.Awake();
    }

    public override void InteractWith()
    {
        if (!isOn)
        {
            audioSource.clip = onSound;
            base.InteractWith();
            isOn = true;
        }

        else if (isOn)
        {
            audioSource.clip = offSound;
            base.InteractWith();
            isOn = false;
        }

    }

}
