using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public Button start,how2,setting,aboutme,exit,home,shome;
    public GameObject am, homepage;
    public GameObject sp;

    public bool swt = false;
    public TextMeshProUGUI controls;
    public Image sound;

	// Use this for initialization
	void Start () {

        start.onClick.AddListener(StartGame);
        how2.onClick.AddListener(How2Play);
        aboutme.onClick.AddListener(AboutMe);
        exit.onClick.AddListener(ExitGame);
        home.onClick.AddListener(Home);
        shome.onClick.AddListener(Shome);
        setting.onClick.AddListener(Setting);

        if (PlayerPrefs.GetString("Controls") == null)
        {
            PlayerPrefs.SetString("Controls", "Buttons");
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Buttons";
        }

        if (PlayerPrefs.GetString("Controls") == "Buttons")
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Buttons";
        }
        else
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Accelerometer";
        }

    }
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}

    void Shome()
    {
        sp.SetActive(false);
        homepage.SetActive(true);
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
        homepage.SetActive(false);
        sp.SetActive(true);
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

    public void Sounds()
    {
       
    }

    public void Controls()
    {
        if (PlayerPrefs.GetString("Controls") == "Acc")
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Buttons";
            PlayerPrefs.SetString("Controls", "Buttons");
        }
        else
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Accelerometer";
            PlayerPrefs.SetString("Controls", "Acc");
        }
             
    }
}
