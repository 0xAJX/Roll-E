using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float smoothTime = 0.3f;
    //public GameObject follower;
    public GameObject sphere;
    Vector3 velocity = Vector3.zero;
   // private Vector3 offset;

	// Use this for initialization
	void Start () {

        //offset = transform.position - sphere.transform.position;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Move();

	}

    void Move()
    {
        //Vector3 targetPosition = sphere.transform.TransformPoint(new Vector3(xOffset, 0, 0));

        //Player p = new Player();

        //velocity = new Vector3(p.speed,0,0);

        //targetPosition = new Vector3(sphere.transform.position.x, 0, 0);
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity , smoothTime);

       transform.position = new Vector3(sphere.gameObject.transform.position.x, transform.position.y, transform.position.z);
    }

   
}
