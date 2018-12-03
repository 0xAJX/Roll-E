using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int mass;

    public float gravity = 10;
    public float speed = 50;
    float jumpVelocity = 4;

    public GameObject finish;
    public GameObject[] road;
    public GameObject block;
    public float blockIndex, wallIndex = 0;

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

    public int turn = 50;

    Collider collider;

    //public Camera camera;

    //public Color colorStart = Color.blue;
    //public Color colorEnd = Color.red;
    //public float duration = 1.0F;

    public Button jump;


    public GameObject[] powerup;

    //Gyro

    //Gyroscope gyro;

    // Use this for initialization
    void Start () {
        
        sphere = GetComponent<Rigidbody>();
        collider = GetComponent<Collider>();

        MakeRoad();

        //left.onClick.AddListener(OnLeftClick);
        //right.onClick.AddListener(OnRightClick);
        jump.onClick.AddListener(Jump);

        HighScore();

        //gyro = EnableGyro();

        //Input.gyro.enabled = true;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

       

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

        if (sphere.position.y <= -1)
        {
            IsDead();
        }

        if (PlayerPrefs.GetString("Controls") == "Buttons")
        {
            

            if (isLeftSelected && isRightSelected)
            {
                //Jump();
            }
            else if (isLeftSelected == true)
            {
                Vector3 v = new Vector3(0, 0, turn);
                sphere.AddForce(v * 100);
            }
            else if (isRightSelected == true)
            {
                Vector3 v = new Vector3(0, 0, -turn);
                sphere.AddForce(v * 100);
            }
        }else if (PlayerPrefs.GetString("Controls") == "Acc")

        {
            UseAcc();
        }


        //float lerp = Mathf.PingPong(Time.time, duration) / duration;
        //RenderSettings.skybox.SetColor("_Tint", Color.Lerp(colorStart, colorEnd, lerp));
    }

    public void Jump()
    {
        sphere.velocity = new Vector3(0,jumpVelocity * 100,0);
        
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


        }

        if (other.tag.Equals("Enemy"))
        {
            IsDead();
        }

        if (other.tag.Equals("SlowTime"))
        {
            Destroy(other);

            StartCoroutine(SlowTime());

        }

        if (other.tag.Equals("Turn"))
        {
            Destroy(other);

            StartCoroutine(IncTurn());

        }
    }

    IEnumerator SlowTime()
    {
        float s = speed;
        //speed = 20f;
        Time.timeScale = 0.7f;
        yield return new WaitForSeconds(5f);
        Time.timeScale = 1f;
        //speed = s;

    }

    IEnumerator IncTurn()
    {
        int t = turn;
        turn = 100;
        yield return new WaitForSeconds(5f);
        turn = t;
    }

    public void MakeRoad()
    {
        //int n = 2;

        int n = UnityEngine.Random.Range(0, 3);

        Vector3 newPosition = new Vector3(wallIndex * 100 -100, 0, 0);
        GameObject newRoad = Instantiate(road[n], newPosition, road[n].transform.rotation);


        Destroy(newRoad, 40);

        if (speed < 18)
        {
            speed += 0.2f;
        }

        if (n == 0)
        {
            SetColor(newRoad);
        }

       
    
            for (int i = 0; i < 10; i++)
            {
                SpawnBlock(n);
            }

        wallIndex++;


        int r = UnityEngine.Random.Range(0,2);

        GameObject powerspawn = Instantiate(powerup[r], new Vector3(newPosition.x,1,UnityEngine.Random.Range(-1,1)), Quaternion.identity);
        Destroy(powerspawn, 50f);

    }

    public void SpawnBlock(int n)
    {

        //if (n == 0)
        //{
            Vector3 newPosition = new Vector3(UnityEngine.Random.Range(blockIndex * 10 - 20, blockIndex * 10 - 10), 1, UnityEngine.Random.Range(-1.0f, 1.0f));

            GameObject newBlock = Instantiate(block, newPosition, Quaternion.identity);

            Destroy(newBlock, 60);
       // }
       

        blockIndex++;

  
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

    public void UseAcc()
    {
        float IOZ = Input.acceleration.x;
        //sphere.AddForce(IOX * 100, 0, 0);

        Vector3 v = new Vector3(0, 0, -IOZ);

        sphere.AddForce(v * 10000 * 2);
    }
}
