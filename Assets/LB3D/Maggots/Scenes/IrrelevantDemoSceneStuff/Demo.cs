using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Demo : MonoBehaviour {

    public GameObject asset;
    public Animator animator;

    public Slider rotate;
    public Slider zoom;
    public Camera cam;

	// Use this for initialization
	void Start () {
        animator = asset.GetComponent<Animator>();
    }

    private void Update()
    {
        asset.transform.eulerAngles = new Vector3(0, rotate.value*360, 0);
        cam.orthographicSize = zoom.value;
    }

    public void Halt() {
        animator.SetBool("isWalking_1", false);
        animator.SetBool("isWalking_2", false);
    }

    public void Walk(string walkNumber) {
        Halt();
        animator.SetBool("isWalking_"+walkNumber, true);
    }

    public void PlayAnim(string animNumber) {
        Halt();
        animator.SetTrigger("anim_"+animNumber);
    }

}
