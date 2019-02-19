using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    //public Component playerComponent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other);
        Debug.Log(other.tag + " TRUED ... ... FROM ENTER 2D");
        GetComponentInParent<PlayerController>().SetGrounded(true);
        //playerComponent.SetGrounded(true);
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log(other.tag + " FALSED ... ... FROM EXIT 2D");
        GetComponentInParent<PlayerController>().SetGrounded(false);
    }
}
