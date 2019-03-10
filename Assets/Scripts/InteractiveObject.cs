using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class InteractiveObject : MonoBehaviour, IInteractive
{
    [Tooltip("The UI text to be displayed when looking at gameobject")]
    [SerializeField]
    protected string displayText = nameof(InteractiveObject);

    public string DisplayText => displayText;

    private AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void InteractWith()
    {
        try
        {
            audioSource.Play();
        }
        catch
        {
            throw new System.Exception("Missing AudioSource component: Interactive Obejct requires an AudioSource on the GameObject");
        }
            Debug.Log($"Player just interacted with {gameObject.name}.");

        //throw new System.NotImplementedException();
    }


}
