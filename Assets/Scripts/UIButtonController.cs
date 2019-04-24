﻿using System.Collections;
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


    Animator blackScreenAnim;

    public void Awake()
    {
        blackScreenAnim = blackScreen.GetComponent<Animator>();
    }

    public void PlayGame()
    {

        blueScreen.SetActive(false);
        rain.SetActive(true);

    }

    public void Credits()
    {
        mainPage.SetActive(false);
        creditsPage.SetActive(true);
    }

    public void Return()
    {
        creditsPage.SetActive(false);
        mainPage.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
