using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public float gravity = 10;
    public float speed = 50;
    float jumpVelocity = 15;

    public GameObject finish;
    public GameObject road;
    public GameObject block;
    public float blockIndex = 0, wallIndex = 0;

    public Rigidbody wall;

    public Rigidbody sphere;

    public Button left, right;
    
    LevelManager levelManager;
    Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.3f;

    public TextMeshProUGUI currentScore, highScore;
    public TextMeshProUGUI winToast;
   
    public int score = 0;

    public bool isLeftSelected = false, isRightSelected = false;

    //public Camera camera;

    public Color colorStart = Color.blue;
    public Color colorEnd = Color.red;
    public float duration = 1.0F;

    // Use this for initialization
    void Start () {

        sphere = GetComponent<Rigidbody>();

        MakeRoad();

        //left.onClick.AddListener(OnLeftClick);
        //right.onClick.AddListener(OnRightClick);

        HighScore();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        score = (int)(Time.timeSinceLevelLoad * 10);
        currentScore.GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();

        GetInput();

        sphere.velocity = new Vector3(speed,0,0);
        wall.velocity = new Vector3(speed - 1.5f, 0, 0);
        sphere.AddForce(new Vector3(0,-gravity,0) * sphere.mass);

        /*if (Mathf.Abs(sphere.position.x - wall.position.x) >= 5)
        {
            wall.transform.Translate(sphere.position.x - 5, 0, 0);
        } */

        if (sphere.position.y <= -3)
        {
            IsDead();
        }

        if (isLeftSelected && isRightSelected)
        {
            Jump();
        }
        else if (isLeftSelected == true)
        {
            Vector3 v = new Vector3(0, 0, 50);
            sphere.AddForce(v * 100);
        }
        else if (isRightSelected == true)
        {
            Vector3 v = new Vector3(0, 0, -50);
            sphere.AddForce(v * 100);
        }

        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, lerp));

    }

    void Jump()
    {
        sphere.velocity = new Vector3(0,jumpVelocity,0);
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
            Debug.Log("Up pressed");
        }
     
    }


    public void OnLeftSelect()
    {
        isLeftSelected = true;
    }

    public void OnRightSelect()
    {
        isRightSelected = true;
    }

    public void OnleftUp()
    {
        isLeftSelected = false;
    }

    public void OnRightUp()
    {
        isRightSelected = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Create"))
        {
            MakeRoad();

            for (int i = 0; i < 15; i++)
            {
                SpawnBlock();
            }

        }

        if (other.tag.Equals("Enemy"))
        {
            IsDead();
        }
    }

    public void MakeRoad()
    {
        Vector3 newPosition = new Vector3(wallIndex * 100 -100, 0, 0);
        GameObject newRoad = Instantiate(road, newPosition, Quaternion.identity);

        SetColor(newRoad);

        wallIndex++;

        Destroy(newRoad, 40);

        if (speed < 18)
        {
            speed += 0.2f;
        }
        
    }

    public void SpawnBlock()
    {

        Vector3 newPosition = new Vector3(UnityEngine.Random.Range(blockIndex * 10 - 20 , blockIndex * 10 - 5) , 1, UnityEngine.Random.Range(-1.0f, 1.0f));

        GameObject newBlock = Instantiate(block, newPosition, Quaternion.identity);

        blockIndex++;

        Destroy(newBlock, 60);
    }

    

    void HighScore()
    {
        if (PlayerPrefs.GetString("HighScore") == null)
        {
            highScore.GetComponent<TextMeshProUGUI>().text = "High Score: 0";
        }
        else
        {
            highScore.GetComponent<TextMeshProUGUI>().text = "High Score: " + PlayerPrefs.GetString("HighScore");
        }
    }

    void IsDead()
    {
        Debug.Log("Game end");

        if (Convert.ToInt32(score) > Convert.ToInt32(highScore))
        {
            winToast.GetComponent<TextMeshProUGUI>().text = "NEW HIGH SCORE!!!";

            PlayerPrefs.SetString("HighScore", score.ToString());
        }

        
        finish.SetActive(true);

        Time.timeScale = 0;
    }

    void SetColor(GameObject gameObject)
    {
        gameObject.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
    }
}
