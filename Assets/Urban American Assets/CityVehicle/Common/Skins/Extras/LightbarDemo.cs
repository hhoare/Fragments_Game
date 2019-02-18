using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightbarDemo : MonoBehaviour {
    public List <Transform> rotor;
    public List <GameObject> lights;
    public bool Lightbar = false;
    bool lightOn;
    public int speed = 2;


    // Use this for initialization
    void Start()
    {
        if (!Lightbar)
        {
            foreach (GameObject Light in lights)
            { Light.SetActive(false);
                lightOn = false;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Lightbar) {
            if (!lightOn)
            {
                foreach (GameObject Light in lights)
                { Light.SetActive(true);
                    lightOn = true;
                }
            }
            foreach (Transform Rotor in rotor) { Rotor.transform.Rotate(0,45* speed * Time.deltaTime, 0); } }
        if (!Lightbar && lightOn)
        {
            foreach (GameObject Light in lights)
            {
                Light.SetActive(false);
                lightOn = false;
            }
        }
    }
}
  

