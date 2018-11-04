using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Button start,how2,setting,aboutme,exit,home;
    public GameObject am, homepage;


	// Use this for initialization
	void Start () {

        start.onClick.AddListener(StartGame);
        how2.onClick.AddListener(How2Play);
        aboutme.onClick.AddListener(AboutMe);
        exit.onClick.AddListener(ExitGame);
        home.onClick.AddListener(Home);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void StartGame()
    {
        //Player p = new Player();

        //p.score = 0;
        SceneManager.LoadScene(1);
    }

    void How2Play()
    {

    }

    void Setting()
    {

    }

    void AboutMe()
    {
        homepage.SetActive(false);
        am.SetActive(true);
    }

    void ExitGame()
    {
        Application.Quit();
    }

    void Home()
    {
        am.SetActive(false);
        homepage.SetActive(true);
    }

    public void Git()
    {
        Application.OpenURL("https://www.github.com/Pr0k1ng/Roll-E");
    }

    public void Live()
    {
        
    }

    public void LinkedIn()
    {
        Application.OpenURL("");
    }
}
