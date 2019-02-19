using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Animator animator;
    public float hMove;
    public float vMove;
    public Vector2 speed;
    public float jumpForce = 500.0f;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float fireRate;
    public string inputXAxis;
    public string inputYAxis;
    public string fireKey;
    public int life;
    public Camera camera;
    //public Text lifeText;
    //public GameObject gameController;
    //public Text scoreText;

    private Rigidbody2D rb2D;
    private Vector2 movement;
    //private bool running;
    public bool facingRight;
    //private bool shooting;
    private float nextFire;
    private bool grounded;
    public Transform groundCheck;
    private float groundRadius = 0.01f;
    public LayerMask whatIsGround;
    private bool dead;
    public bool hurt;
    private GameObject gameController;
    private GameController GC;
    //private int score;

    void Awake() {
        //Instantiate(camera, transform.position, transform.rotation);
    }

	// Use this for initialization
	void Start () {
        //running = false;
        if (!facingRight)
            FlipPlayer(180f);
        //facingRight = true;
        //shooting = false;
        grounded = false;
        dead = false;
        hurt = false;
        life = 100;
        //lifeText.text = life.ToString();
        rb2D = GetComponent<Rigidbody2D>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        GC = gameController.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!dead) {
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
            Move();
            Shoot();
            //Jump();
            CheckHurt();
            CheckLife();
        }
	}

    void FixedUpdate() {
        if (gameObject.CompareTag("Player1")) {
            Debug.Log(grounded);
        }
        if (!dead) {
            Jump();
            rb2D.velocity = movement;
        }
    }

    void Move() {
        hMove = Input.GetAxis(inputXAxis);

        //Debug.Log(movement);
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        movement = new Vector2(speed.x * hMove, rb2D.velocity.y);
        if (hMove > 0f) {
            if (!facingRight) {
                facingRight = true;
                FlipPlayer(0f);
            }
            animator.SetBool("Running", true);
        } else if (hMove < 0f) {
            if (facingRight) {
                facingRight = false;
                FlipPlayer(180f);
            }
            animator.SetBool("Running", true);
        } else {
            animator.SetBool("Running", false);
        }
    }

    void FlipPlayer(float angle){
        transform.localRotation = Quaternion.Euler(0, angle, 0);
    }

    void Shoot() {
        nextFire = Time.time * fireRate;
        if (Input.GetButtonDown(fireKey) && Time.time > nextFire) {
            animator.SetBool("Shooting", true);
            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        } else {
            animator.SetBool("Shooting", false);
        }
    }

    void Jump() {
        if (Input.GetButtonDown(inputYAxis) && grounded) {
            //Debug.Log("JUMPED");
            rb2D.AddForce(new Vector2(0, jumpForce));
            //grounded = false;
        }
    }

    void CheckHurt() {
        if (hurt) {
            animator.Play(gameObject.tag + "Hurt");
            hurt = false;
            life -= 20;
        }
    }

    void CheckLife() {
        //lifeText.text = life.ToString();
        if (gameObject.CompareTag("Player1"))
        {
            GC.SetP1Life(life);
        }
        else {
            GC.SetP2Life(life);
        }
        if (life <= 0) {
            Dead();
        }
    }

    void Dead() {
        dead = true;
        animator.Play(gameObject.tag + "Die");
        if (gameObject.CompareTag("Player1"))
        {
            GC.SetP1Dead(true);
        }
        else {
            GC.SetP2Dead(true);
        }
        Destroy(gameObject, 3.0f);
    }

    public void SetGrounded(bool flag) {
        grounded = flag;
    }

    public void SetDead(bool flag) {
        dead = flag;
    }

    public void SetHurt(bool flag) {
        hurt = flag;
    }
}
