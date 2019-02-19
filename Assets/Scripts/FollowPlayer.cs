using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public float smoothing = 6f;
    public Transform player;
    private Vector3 camOffset;
    //public Transform positionTarget;

    void Awake() {
        if (player != null)
            transform.position = player.position;
    }

	// Use this for initialization
	void Start () {
        if (player != null)
            camOffset = transform.position - player.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(camOffset);
        /*if (player == null)
            return;
        transform.position = player.position;*/
	}

    void LateUpdate() {
        if (player != null) {
            //Debug.Log(player.position);
            //transform.position = Vector3.Lerp(transform.position, positionTarget.position, Time.deltaTime * smoothing);
            //transform.LookAt(player);
            transform.position = new Vector3(player.position.x, 0, (player.position.z - 10f)) + camOffset;
        }
    }

    public void SetPosition(Vector3 v) {
        transform.position = v;
    }

    public void SetCamOffset(Vector3 v) {
        camOffset = v;
    }

    public void ResetCamOffset() {
        camOffset = transform.position - player.position;
    }

    public void ReSetup() {
        if (player != null) {
            Awake();
            Start();
        }
        //transform.position = player.position;
        //camOffset = transform.position - player.position;
    }
}
