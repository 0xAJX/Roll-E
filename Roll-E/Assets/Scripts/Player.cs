using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    float speed = 5;
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
   
    public int score = 0;
    

    // Use this for initialization
    void Start () {

        score = 0;
        sphere = GetComponent<Rigidbody>();

        MakeRoad();

        left.onClick.AddListener(OnLeftClick);
        right.onClick.AddListener(OnRightClick);

        

        HighScore();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        score = (int)(Time.timeSinceLevelLoad * 10);
        currentScore.GetComponent<TextMeshProUGUI>().text = "SCORE: " + score.ToString();

        GetInput();

        sphere.velocity = new Vector3(speed,0,0);
        wall.velocity = new Vector3(speed - 0.5f, 0, 0);

        /*if (Mathf.Abs(sphere.position.x - wall.position.x) >= 5)
        {
            wall.transform.Translate(sphere.position.x + 5, 0, 0);
        } */
	}

    void Jump()
    {
        sphere.velocity = new Vector3(0,10,0);
    }

    void GetInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Jump();
            Debug.Log("Up pressed");
        }
     
    }

    IEnumerable Wait()
    {
        yield return new WaitForSeconds(0.3f);   
    }

    void OnLeftClick()
    {

        if (sphere.transform.position.z >= 1f)
        {

        }
        else
        {

            Vector3 v = new Vector3(sphere.position.x, sphere.position.y, sphere.position.z + 1);

            /*for (float i=0 ; i <= 1f ; i += .1f)
            {

                sphere.position = Vector3.MoveTowards(sphere.position, v, 0.1f);
                //sphere.position = Vector3.Lerp(sphere.position, v, i);
                //Wait();  
            } */


           

            

            sphere.transform.Translate(0, 0, 1);
           

            //float a = sphere.position.z;

            //Vector3 b = new Vector3(sphere.position.x, sphere.position.y, 1);

            //sphere.position = b;
        }
        
    }

    void OnRightClick()
    {

        if (sphere.transform.position.z <= -1f)
        {

        }
        else
        {

            Vector3 v = new Vector3(sphere.position.x, sphere.position.y, sphere.position.z-1);
            
            /*for (float i=0; i <= 1f; i += .1f)
            {
                sphere.position = Vector3.Lerp(sphere.position, v, i);
                Wait();
            } */

           // sphere.position = Vector3.SmoothDamp(sphere.position, v, ref velocity, 0f);

            sphere.transform.Translate(0, 0, -1);
            //Vector3 v = new Vector3(sphere.position.x, sphere.position.y, -1);
            //sphere.position = Vector3.Lerp(sphere.position, v, 1f);

            /*float a = sphere.position.z;

            Vector3 b = new Vector3(sphere.position.x,sphere.position.y , (int)Mathf.Ceil(a));

            sphere.position = b;*/
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag.Equals("Create"))
        {
            MakeRoad();

            for (int i = 0; i < 20; i++)
            {
                SpawnBlock();
            }

        }

        if (other.tag.Equals("Enemy"))
        {

            Debug.Log("Game end");

            PlayerPrefs.SetString("HighScore", score.ToString());

            finish.SetActive(true);

            Time.timeScale = 0;
        }
    }

    public void MakeRoad()
    {
        Vector3 newPosition = new Vector3(wallIndex * 100 -100, 0, 0);
        GameObject newRoad = Instantiate(road, newPosition, Quaternion.identity);

        wallIndex++;

        Destroy(newRoad, 50);
    }

    public void SpawnBlock()
    {
        int randomPositionZ = Random.Range(-1, 1);

        Vector3 newPosition = new Vector3(blockIndex * 10, 1, randomPositionZ);

        GameObject newBlock = Instantiate(block, newPosition, Quaternion.identity);

        blockIndex++;

        Destroy(newBlock, 50);
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
}
