using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public GameObject p1Prefab;
    public GameObject p2Prefab;
    public GameObject p1Camera;
    public GameObject p2Camera;
    public Transform p1Spawn;
    public Transform p2Spawn;
    public Text p1LifeText;
    public Text p2LifeText;
    public Text p1ScoreText;
    public Text p2ScoreText;

    private int p1Life;
    private int p2Life;
    private int p1Score;
    private int p2Score;
    private bool p1Dead;
    private bool p2Dead;

	// Use this for initialization
	void Start () {
        p1Score = 0;
        p2Score = 0;
        StartCoroutine(ReSpawnPlayer(p1Prefab, p1Spawn, 0.0f, "p1"));
        StartCoroutine(ReSpawnPlayer(p2Prefab, p2Spawn, 0.0f, "p2"));
	}
	
	// Update is called once per frame
	void Update () {
        UpdatePlayersLife();
        UpdatePlayersScore();
        CheckDead();
	}

    public void SetP1Score(int score) {
        p1Score = score;
    }

    public int GetP1Score() {
        return p1Score;
    }

    public void SetP2Score(int score) {
        p2Score = score;
    }

    public int GetP2Score() {
        return p2Score;
    }

    public void SetP1Dead(bool flag) {
        p1Dead = flag;
    }

    public bool GetP1Dead(bool flag) {
        return p1Dead;
    }

    public void SetP2Dead(bool flag) {
        p2Dead = flag;
    }

    public bool GetP2Dead(bool flag) {
        return p2Dead;
    }

    public void SetP1Life(int life) {
        p1Life = life;
    }

    public void SetP2Life(int life) {
        p2Life = life;
    }

    void UpdatePlayersLife() {
        p1LifeText.text = p1Life.ToString();
        p2LifeText.text = p2Life.ToString();
    }

    void UpdatePlayersScore() {
        p1ScoreText.text = p1Score.ToString();
        p2ScoreText.text = p2Score.ToString();
    }

    void CheckDead() {
        if (p1Dead) {
            p2Score++;
            p1Dead = false;
            StartCoroutine(ReSpawnPlayer(p1Prefab, p1Spawn, 1.0f, "p1"));
            //Invoke("ReSpawnPlayer(p1Prefab, p1Spawn)", 3.0f);
            //ReSpawnPlayer(p1Prefab, p1Spawn);
        }else if(p2Dead){
            p1Score++;
            p2Dead = false;
            StartCoroutine(ReSpawnPlayer(p2Prefab, p2Spawn, 1.0f, "p2"));
            //Invoke("ReSpawnPlayer(p2Prefab, p2Spawn)", 3.0f);
            //ReSpawnPlayer(p1Prefab, p2Spawn);
        }
    }

    IEnumerator ReSpawnPlayer(GameObject playerPrefab, Transform transform, float waitSec, string p) {
        yield return new WaitForSeconds(waitSec);
        GameObject player = Instantiate(playerPrefab, transform.position, transform.rotation);
        if (p == "p1")
        {
            p1Camera.GetComponent<FollowPlayer>().player = player.transform;
            //p1Camera.GetComponent<FollowPlayer>().SetPosition(transform.position);
            //p1Camera.GetComponent<FollowPlayer>().ResetCamOffset();
            p1Camera.GetComponent<FollowPlayer>().ReSetup();
        }
        else {
            p2Camera.GetComponent<FollowPlayer>().player = player.transform;
            //p2Camera.GetComponent<FollowPlayer>().SetPosition(transform.position);
            //p2Camera.GetComponent<FollowPlayer>().ResetCamOffset();
            p2Camera.GetComponent<FollowPlayer>().ReSetup();
        }
    }
}
