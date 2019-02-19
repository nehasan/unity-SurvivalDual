using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour {

    private Rigidbody2D rb2D;
    public float speed = 15.0f;
    private PlayerController playerController;
    private GameObject gameController;
    private GameController GC;

    void Awake() {
        gameController = GameObject.FindGameObjectWithTag("GameController");
        GC = gameController.GetComponent<GameController>();
    }

	// Use this for initialization
	void Start () {
        rb2D = GetComponent<Rigidbody2D>();
        //gameController = GameObject.FindGameObjectWithTag("GameController");
        //GC = gameController.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        rb2D.velocity = transform.right * speed;
	}

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log("HELLO");
        //Animator animator = other.gameObject.GetComponent<PlayerController>().animator;
        
        if (gameObject.CompareTag("P1Bullet") && other.gameObject.CompareTag("Player2"))
        {
            //other.gameObject.GetComponent<PlayerController>().animator.Play(other.gameObject.tag + "Die");
            //other.gameObject.GetComponent<PlayerController>().SetDead(true);
            playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.SetHurt(true);
            //playerController.life -= 20;
            //GC.SetP1Score(GC.GetP1Score() + 1);
            Destroy(gameObject);
        }
        else if (gameObject.CompareTag("P2Bullet") && other.gameObject.CompareTag("Player1"))
        {
            //other.gameObject.GetComponent<PlayerController>().animator.Play(other.gameObject.tag + "Die");
            //other.gameObject.GetComponent<PlayerController>().SetDead(true);
            playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.SetHurt(true);
            //playerController.life -= 20;
            //GC.SetP2Score(GC.GetP2Score() + 1);
            Destroy(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
}
