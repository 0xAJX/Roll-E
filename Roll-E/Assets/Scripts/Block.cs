using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.y < -2)
        {
            Destroy(gameObject);
        }

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Turn" || other.tag == "SlowTime")
        {
            Destroy(gameObject);
        }
    }
}
