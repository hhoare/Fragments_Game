using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolumeEnter : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject objectToEnable;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Collider>();
    }


    protected AudioSource audioSource;

    protected virtual void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other == player.GetComponent<Collider>()) {
            StartCoroutine(ActivateAfterDelay(7));

        }
    }


    IEnumerator ActivateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        objectToEnable.SetActive(true);
        audioSource.Play();

    }

}
