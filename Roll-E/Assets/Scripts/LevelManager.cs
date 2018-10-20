using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Button start,how2,aboutme, exit;

	// Use this for initialization
	void Start () {

        start.onClick.AddListener(StartGame);
        how2.onClick.AddListener(How2Play);
        aboutme.onClick.AddListener(AboutMe);
        exit.onClick.AddListener(ExitGame);

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void How2Play()
    {

    }

    void AboutMe()
    {

    }

    void ExitGame()
    {
        Application.Quit();
    }

}
