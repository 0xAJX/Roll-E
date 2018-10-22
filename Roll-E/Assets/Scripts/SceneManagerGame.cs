using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerGame : MonoBehaviour {

    public Button menu,resume,settings,quit,retry,exit;
    public GameObject go;

    // Use this for initialization
    void Start () {

        //menu.onClick.AddListener(OnSelectMenu);
        resume.onClick.AddListener(Resume);
        settings.onClick.AddListener(Settings);
        quit.onClick.AddListener(Quit);
        exit.onClick.AddListener(Quit);
        retry.onClick.AddListener(Retry);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        
    }

    void Resume()
    {
        Time.timeScale = 1;
        go.SetActive(false);
    }

    void Settings()
    {
        
    }

    void Quit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void OnSelectMenu()
    {
            Time.timeScale = 0;
            go.SetActive(true);
    }

}
