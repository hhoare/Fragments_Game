using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonController : MonoBehaviour
{
    [SerializeField]
    GameObject blueScreen;
    [SerializeField]
    GameObject blackScreen;
    [SerializeField]
    GameObject rain;

    [SerializeField]
    GameObject mainPage;
    [SerializeField]
    GameObject creditsPage;


    [SerializeField]
    SceneChangeTimer sceneChanger;

    protected AudioSource audioSource;



    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        sceneChanger.enabled = false;
    }

    public void PlayGame()
    {
        playButtonSound();
        blackScreen.SetActive(true);
        blueScreen.SetActive(false);
        rain.SetActive(true);
        sceneChanger.enabled = true;

    }

    public void Credits()
    {
        playButtonSound();
        mainPage.SetActive(false);
        creditsPage.SetActive(true);
    }

    public void Return()
    {
        playButtonSound();
        creditsPage.SetActive(false);
        mainPage.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Assets() {
        playButtonSound();
        Application.OpenURL("https://docs.google.com/document/d/17cH8SetIxL2JD8lVcnuzv-C29i_M94zzNdPNWHiAwIg/edit?usp=sharing");

    }

    public void playButtonSound()
    {
        audioSource.Play();

    }


}
