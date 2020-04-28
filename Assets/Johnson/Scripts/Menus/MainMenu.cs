using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button viewGalaxy;
    public Button credits;
    public Button exit;
    public Button back;

    public GameObject menu;
    public GameObject title;
    public GameObject creditsBox;
    
    public Canvas gameMenu;

    bool isViewGalaxy = false;
    bool isTitlescreen = true;
    bool isCreditsClicked = false;

    public Camera mmCamera;
    public Camera frCamera;


    void Start()
    {
        viewGalaxy.onClick.AddListener(GalaxyClicked);
        credits.onClick.AddListener(CreditsClicked);
        exit.onClick.AddListener(ExitClicked);
        back.onClick.AddListener(BackClicked);
    }

    // Update is called once per frame
    void Update()
    {
        if (isTitlescreen)
        {
            mmCamera.enabled = true;
            frCamera.enabled = false;
            gameMenu.enabled = false;
            creditsBox.SetActive(false);
        }
        
        
    }

    void GalaxyClicked()
    {
        menu.SetActive(false);
        title.SetActive(false);

        mmCamera.enabled = false;
        frCamera.enabled = true;
        gameMenu.enabled = true;
        isTitlescreen = false;
    }

    void CreditsClicked()
    {
        creditsBox.SetActive(true);
        menu.SetActive(false);
        title.SetActive(false);
        isTitlescreen = false;
    }

    void BackClicked()
    {
        creditsBox.SetActive(false);
        menu.SetActive(true);
        title.SetActive(true);
        isTitlescreen = true;
    }

    void ExitClicked()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        
    }

    
}
