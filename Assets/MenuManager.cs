using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject tutorialMenu;
    [SerializeField] GameObject creditsMenu;

    public void ActivateCredits()
    {
        tutorialMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void ActivateTutorial()
    {
        tutorialMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
