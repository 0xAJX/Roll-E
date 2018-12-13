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

    public GameObject loadingObj;
    public Slider slider;

    public TextMeshProUGUI quality;
    AsyncOperation async;

	// Use this for initialization
	void Start () {

        start.onClick.AddListener(StartGame);
        how2.onClick.AddListener(How2Play);
        aboutme.onClick.AddListener(AboutMe);
        exit.onClick.AddListener(ExitGame);
        home.onClick.AddListener(Home);
        shome.onClick.AddListener(Shome);
        setting.onClick.AddListener(Setting);


        if (PlayerPrefs.GetInt("Quality", 0) == 0)
        {
            PlayerPrefs.SetInt("Quality", 2);
            quality.GetComponent<TextMeshProUGUI>().text = "Quality : Low";
            QualitySettings.SetQualityLevel(2, false);
        }
        else if (PlayerPrefs.GetInt("Quality") == 2)
        {
            //PlayerPrefs.SetInt("Quality", 2);
            quality.GetComponent<TextMeshProUGUI>().text = "Quality : Low";
            QualitySettings.SetQualityLevel(2, false);
        }
        else if (PlayerPrefs.GetInt("Quality") == 5)
        {
            //PlayerPrefs.SetInt("Quality", 5);
            quality.GetComponent<TextMeshProUGUI>().text = "Quality : High";
            QualitySettings.SetQualityLevel(2, true);
        }
       

            PlayerPrefs.SetString("Controls", "Touch");
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Touch";
    

        /*if (PlayerPrefs.GetString("Controls") == "Touch")
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Touch";
        }
        else if(PlayerPrefs.GetString("Controls") == "Acc")
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Accelerometer";
        }*/

        /*if (PlayerPrefs.GetString("Sound") == null)
        {
            PlayerPrefs.SetString("Sound", "on");
        }

        if (PlayerPrefs.GetString("Sound") == "on")
        {
            //controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Touch";
        }
        else
        {
            //controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Accelerometer";
        } */

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
        //SceneManager.LoadScene(1);

        homepage.SetActive(false);
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        loadingObj.SetActive(true);
        async = SceneManager.LoadSceneAsync(1);
        async.allowSceneActivation = false;

        while (async.isDone == false)
        {
            slider.value = async.progress;
            if (async.progress == 0.9f)
            {
                slider.value = 1f;
                async.allowSceneActivation = true;
            }

            yield return null;
        }


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
        string email = "abhishek.jadhav64@live.com";
        string subject = "";
        string body = "";

        Application.OpenURL("mailto:" + email + "?subject=" + subject + "&body=" + body);
    }

    public void LinkedIn()
    {
        Application.OpenURL("https://www.linkedin.com/in/abhishek-jadhav-36197898");
    }

    public void Sounds()
    {
        /*if (PlayerPrefs.GetString("Sound") == "on")
        {

        }
        else
        {

        } */
    }

    public void Controls()
    {
        if (PlayerPrefs.GetString("Controls") == "Acc")
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Touch";
            PlayerPrefs.SetString("Controls", "Touch");
        }
        else if(PlayerPrefs.GetString("Controls") == "Touch")
        {
            controls.GetComponent<TextMeshProUGUI>().text = "Controls :" + " Accelerometer";
            PlayerPrefs.SetString("Controls", "Acc");
        }
             
    }

    public void Quality()
    {
        if (PlayerPrefs.GetInt("Quality") == 2)
        {
            PlayerPrefs.SetInt("Quality", 5);
            quality.GetComponent<TextMeshProUGUI>().text = "Quality : High";
            QualitySettings.SetQualityLevel(2, true);
        }
        else if(PlayerPrefs.GetInt("Quality") == 5)
        {
            PlayerPrefs.SetInt("Quality", 2);
            quality.GetComponent<TextMeshProUGUI>().text = "Quality : Low";
            QualitySettings.SetQualityLevel(2, false);
        }
    }
}
