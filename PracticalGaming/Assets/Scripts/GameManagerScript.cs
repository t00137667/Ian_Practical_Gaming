using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public  class GameManagerScript : MonoBehaviour {

    float gameTime = 0;
    float newTime = 0;

    SpawnerScript spawner;
    Text scorekeeper, speedometer;
    public AudioClip gunShot;
    public AudioClip missile;
    public AudioClip shieldHit;
    public AudioClip shipDeath;

    AudioSource source;

    static List<GameObject> EnemyShips = new List<GameObject>();
    MovementControlScript player;

    int shipCount = 1;
    int score = 0;
    float speed = 0;

    static TargetObjective target;
    static Transform playerPosition;

    private void Awake()
    {
        target = FindObjectOfType<TargetObjective>();
        player = FindObjectOfType<MovementControlScript>();

        scorekeeper = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        speedometer = GameObject.FindGameObjectWithTag("Speed").GetComponent<Text>();

        source = gameObject.AddComponent<AudioSource>();
    }

    // Use this for initialization
    void Start () {
        newTime = gameTime + 1;

        spawner = GetComponentInChildren<SpawnerScript>();

        // Needs adjustment for actual play, just for testing at the moment
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {

        if (target == null)
            playerPosition = player.transform;

        gameTime += Time.deltaTime;

        if (newTime <= gameTime)
        {
            newTime = gameTime + 1;

            if (shipCount < 20)
            {
                spawner.SpawnEnemyShip(0);
                AddEnemyShip();
            }
            CheckIfInRange();
        }

        if (player != null)
            speed = player.speed;

        speedometer.text = "Speed: " + speed.ToString("N");
        scorekeeper.text = "Score: " + score.ToString();

        if (target == null && player == null)
        {
            GameOver();
        }

    }

    public void AddEnemyShip()
    {
        EnemyShips.Add(SpawnerScript.GetShip());
        shipCount = EnemyShips.Count;
    }

    public static Transform RequestTargetPosition()
    {
        if (target == null)
        {
            return playerPosition.transform;
        }
        else
        return target.transform;
    }

    private void CheckIfInRange()
    {
        foreach(GameObject g in EnemyShips)
        {
            if (g != null)
            {
                if (g.GetComponent<MovementControlScript>().inRange)
                {
                    g.GetComponentInChildren<WeaponControl>().FireBullets();
                    g.GetComponentInChildren<WeaponControl>().FireBullets();
                }
            }
            
        }
    }

    public GameObject ProvideTarget(GameObject turret)
    {
        GameObject closestTarget = null;

        foreach(GameObject t in EnemyShips)
        {
            if (t != null)
            {
                if (closestTarget == null) closestTarget = t;

                if (Vector3.Distance(turret.transform.position, t.transform.position) < Vector3.Distance(turret.transform.position, closestTarget.transform.position))
                {
                    closestTarget = t;
                }
            }
        }

        return closestTarget;
    }
    private void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        //SceneManager.LoadScene("GameOver");
    }

    private void IncrementScore()
    {
        score++;
        shipCount--;
    }

    public void DestroyShip(GameObject g)
    {
        EnemyShips.Remove(g);

        source.PlayOneShot(shipDeath);

        Destroy(g);

        IncrementScore();
    }
}
