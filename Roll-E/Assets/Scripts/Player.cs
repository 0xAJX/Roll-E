using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    float speed = 5;
    float jumpVelocity = 15;

    public GameObject road;
    public GameObject block;
    public float blockIndex = 0, wallIndex = 0;

    public Rigidbody wall;

    public Rigidbody sphere;

    LevelManager levelManager;

    // Use this for initialization
    void Start () {
        sphere = GetComponent<Rigidbody>();

        MakeRoad();
	}
	
	// Update is called once per frame
	void Update () {

        GetInput();

        sphere.velocity = new Vector3(speed,0,0);
        wall.velocity = new Vector3(speed, 0, 0);
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
        else if (Input.GetKeyDown(KeyCode.A))
        {

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {

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


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Enemy"))
        {
            Time.timeScale = 0;
            Debug.Log("Game end");
        }
    }
}
